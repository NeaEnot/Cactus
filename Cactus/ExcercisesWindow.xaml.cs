using Core;
using System.Linq;
using Core.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;

namespace Cactus
{
    /// <summary>
    /// Логика взаимодействия для ExcercisesWindow.xaml
    /// </summary>
    public partial class ExcercisesWindow : Window
    {
        private ILogic logic;

        public ExcercisesWindow(ILogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void treeView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<ExcerciseView> list = logic.Read(null);

            treeView.Items.Clear();

            foreach (ExcerciseView model in list)
            {
                string[] hierarchicalName = model.Title.Split('.');

                AddNodeToTree(hierarchicalName, 0, treeView.Items);
            }
        }

        private void AddNodeToTree(string[] hierarchicalName, int index, ItemCollection items)
        {
            TreeViewItem item = null;

            for (int i = 0; i < items.Count; i++)
            {
                if ((string)(items[i] as TreeViewItem).Header == hierarchicalName[index])
                {
                    item = items[i] as TreeViewItem;
                }    
            }

            if (item == null)
            {
                item = new TreeViewItem();
                item.Header = hierarchicalName[index];

                items.Add(item);
            }

            if (index != hierarchicalName.Length - 1)
            {
                AddNodeToTree(hierarchicalName, index + 1, item.Items);
            }
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            ExcerciseView model = GetSelectedItem();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            ExcerciseView model = GetSelectedItem();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcerciseView model = GetSelectedItem();
                logic.Delete(new ExcerciseBinding { Id = model.Id });
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private ExcerciseView GetSelectedItem()
        {
            string title = GetSelectedTitle();

            List<ExcerciseView> list = logic.Read(new ExcerciseBinding { Title = title });
            ExcerciseView excercise = list.FirstOrDefault(rec => rec.Title == title);

            if (excercise != null)
            {
                return list[0];
            }
            else
            {
                throw new Exception("Выбран элемент не конечного уровня");
            }
        }

        private string GetSelectedTitle()
        {
            TreeViewItem node = treeView.SelectedItem as TreeViewItem;
            string title = node.Header.ToString();

            while (node.Parent is TreeViewItem)
            {
                node = node.Parent as TreeViewItem;
                title = node.Header.ToString() + "." + title;
            }

            return title;
        }
    }
}
