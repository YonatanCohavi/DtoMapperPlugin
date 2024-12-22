using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DtoMapperPlugin.Controllers
{
    public partial class FilteredSelectList : UserControl
    {
        private readonly List<FilteredListItem> _items = new List<FilteredListItem>();
        private readonly HashSet<string> _selectedKeys = new HashSet<string>();
        private bool _hasType;
        public event Action<IEnumerable<FilteredListItem>> SelectedItemsChanged;
        public IReadOnlyCollection<string> SelectedKeys => _selectedKeys;
        public string Title { get => title.Text; set => title.Text = value; }
        public bool CheckBoxes { get => listView.CheckBoxes; set => listView.CheckBoxes = value; }
        public bool HasType { get => _hasType; set => SetHasType(value); }
        private bool _invokeCheckEvent = true;
        public void CheckItem(string key)
        {
            if (!CheckBoxes)
                return;
            var lvi = listView.Items.Cast<ListViewItem>().FirstOrDefault(i => (string)i.Tag == key);
            if (lvi == null)
                return;
            lvi.Checked = true;
            InternalCheckItem(lvi);
        }
        private void SetHasType(bool value)
        {
            if (_hasType == value)
                return;
            _hasType = value;
            if (_hasType)
                listView.Columns.Add("Type", "Type", 50);
            else
                listView.Columns.RemoveByKey("Type");
        }

        public FilteredSelectList()
        {
            InitializeComponent();
        }

        public void SetItems(IEnumerable<FilteredListItem> items, bool clearSelection)
        {
            _items.Clear();
            if (clearSelection)
                _selectedKeys.Clear();
            _items.AddRange(items);
            SetListItems();
            SelectedItemsChanged?.Invoke(Array.Empty<FilteredListItem>());

        }
        public void Reset()
        {
            _selectedKeys.Clear();
            _items.Clear();
            _invokeCheckEvent = true;
            listView.Items.Clear();
        }
        private void SetListItems()
        {
            var filterText = filtertextBox.Text?.ToLower() ?? string.Empty;
            listView.Items.Clear();
            _invokeCheckEvent = false;
            listView.Items.AddRange(_items.Where(i => string.IsNullOrEmpty(filterText) || i.Text.ToLower().Contains(filterText)).Select(i => CreateItem(i)).ToArray());
            _invokeCheckEvent = true;
            ResizeColumns();
        }

        private static Font _boldFont;
        private ListViewItem CreateItem(FilteredListItem item)
        {
            var listViewItem = new ListViewItem(new[] { item.Text, item.Type })
            {
                Tag = item.Key
            };

            if (CheckBoxes && _selectedKeys.Contains(item.Key))
                listViewItem.Checked = true;

            if (item.Disabled)
                listViewItem.ForeColor = Color.LightGray;
            if (_boldFont == null)
                _boldFont = new Font(listViewItem.Font, FontStyle.Bold);
            if (item.Bold)
                listViewItem.Font = _boldFont;
            return listViewItem;
        }

        private void filterChanged(object sender, System.EventArgs e)
        {
            SetListItems();
        }

        private void ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.ForeColor == Color.LightGray)
            {
                e.Item.Checked = false;
                return;
            }
            InternalCheckItem(e.Item);
        }

        private void InternalCheckItem(ListViewItem item)
        {

            var key = (string)item.Tag;
            bool selectedChanged;
            if (!CheckBoxes)
            {
                _selectedKeys.Clear();
                _selectedKeys.Add(key);
                selectedChanged = true;
            }
            else
            {
                if (!item.Checked)
                    selectedChanged = _selectedKeys.Remove(key);
                else
                    selectedChanged = _selectedKeys.Add(key);
            }
            if (!selectedChanged)
                return;

            if (_invokeCheckEvent)
            {
                var selectedItems = _items.Where(i => _selectedKeys.Contains(i.Key));
                SelectedItemsChanged?.Invoke(selectedItems);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBoxes)
                return;
            if (listView.SelectedIndices.Count == 0)
                return;

            var selectedItem = listView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            var item = _items.First(i => i.Key == (string)selectedItem.Tag);
            _selectedKeys.Clear();
            _selectedKeys.Add(item.Key);
            SelectedItemsChanged?.Invoke(new[] { item });
        }


        private void ResizeColumns()
        {
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            var listWidth = listView.Width;
            var totalColumnsWidth = listView.Columns.Cast<ColumnHeader>().Sum(c => c.Width);
            var ratio = 1m * listWidth / totalColumnsWidth;
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                var colWidth = Convert.ToInt32(listView.Columns[i].Width * ratio) - 2;
                listView.Columns[i].Width = colWidth;
            }
        }
        private void FilteredSelectList_Resize(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            if (!CheckBoxes)
                return;
            _invokeCheckEvent = false;
            var selectedCount = _selectedKeys.Count;

            foreach (ListViewItem item in listView.Items)
                item.Checked = true;

            _invokeCheckEvent = true;

            var changed = selectedCount != _selectedKeys.Count;
            if (changed)
            {
                var selectedItems = _items.Where(i => _selectedKeys.Contains(i.Key));
                SelectedItemsChanged?.Invoke(selectedItems);
            }
        }

        private void clearSelection_Click(object sender, EventArgs e)
        {
            if (!CheckBoxes)
                return;

            _invokeCheckEvent = false;

            var selectedCount = _selectedKeys.Count;
            foreach (ListViewItem item in listView.Items)
                item.Checked = false;

            _invokeCheckEvent = true;

            var changed = selectedCount != _selectedKeys.Count;
            if (changed)
            {
                var selectedItems = _items.Where(i => _selectedKeys.Contains(i.Key));
                SelectedItemsChanged?.Invoke(selectedItems);
            }
        }
    }
}
