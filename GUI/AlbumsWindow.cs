using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vezba26062021.BuissnesLogic;
using Vezba26062021.BuissnesLogic.Albums;

namespace Vezba26062021.GUI
{
    public partial class AlbumsWindow : Form
    {
        public AlbumsWindow()
        {
            InitializeComponent();
            LoadGrid();
        }
        private void LoadGrid()
        {
            
            var operation = new SelectAlbumOperation();
            var keyword = this.tbSearch.Text;
            if (!string.IsNullOrEmpty(keyword))
            {
                operation.Keyword = keyword;
            }
            OperationResult result = OperationManager.Instance.ExecuteOperation(operation);
            if (result.IsSuccessful)
            {
                var albums = result.Data as IEnumerable<AlbumDTO>;

                this.dgAlbums.DataSource = albums;
                this.dgAlbums.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                MessageBox.Show(result.Errors.First());
            }
        }
        private AlbumDTO SelectedAlbum
        {
            get
            {
                if(this.dgAlbums.SelectedRows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return this.dgAlbums.SelectedRows[0].DataBoundItem as AlbumDTO;
                }
            }
        }
        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dodajNoviAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addNewAlbumWindow = new AddEditAlbumWindow(null);
            addNewAlbumWindow.Show();

            addNewAlbumWindow.Disposed += (x, y) =>
            {
                LoadGrid();
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedAlbum == null)
            {
                MessageBox.Show("Izaberite album za brisanje!");
                return;
            }
            else
            {
                var idToDelete = SelectedAlbum.Id;

                var operation = new DeleteAlbumOperation(idToDelete);

                var result = OperationManager.Instance.ExecuteOperation(operation);

                if (result.IsSuccessful)
                {
                    MessageBox.Show("Uspesno ste izbrisali!");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show(result.Errors.First());
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(SelectedAlbum == null)
            {
                MessageBox.Show("Morate da izaberete album");
                return;
            }
            else
            {
                var editAlbum = new AddEditAlbumWindow(SelectedAlbum);
                editAlbum.Show();

                editAlbum.Disposed += (x, y) =>
                {
                    LoadGrid();
                };
            }
        }
    }
}
