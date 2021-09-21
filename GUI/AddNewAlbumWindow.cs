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
using Vezba26062021.BuissnesLogic.Artist;

namespace Vezba26062021.GUI
{
    public partial class AddEditAlbumWindow : Form
    {
        private AlbumDTO _dto;
        public AddEditAlbumWindow(AlbumDTO dto)
        {
            _dto = dto;
            InitializeComponent();
            var operation = new SelectArtistOperation();
            OperationResult result = OperationManager.Instance.ExecuteOperation(operation);
            if (result.IsSuccessful)
            {
                cbArtist.DisplayMember = "Name";
                cbArtist.ValueMember = "Id";
                cbArtist.DataSource = result.Data as IEnumerable<ArtistDTO>;

                if (_dto != null)
                {
                    var artistToPreselect = result.Data.FirstOrDefault(x => x.Id == _dto.ArtistId);
                    this.cbArtist.SelectedItem = artistToPreselect;
                    this.tbAlbumName.Text = _dto.Title;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            var artistId = (cbArtist.SelectedItem as ArtistDTO).Id;
            var titleName = tbAlbumName.Text;


            if (_dto == null)
            {
                var album = new AlbumDTO
                {
                    ArtistId = artistId,
                    Title = titleName
                };
                var operation = new AddNewAlbumOperation(album);

                var result = OperationManager.Instance.ExecuteOperation(operation);
                if (result.IsSuccessful)
                {
                    MessageBox.Show("Uspesno ste uneli album");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(result.Errors.First());
                }
            }
            else
            {
                var albumId = _dto.Id;
                var album = new AlbumDTO
                {
                    Id = albumId,
                    ArtistId = artistId,
                    Title = titleName
                };

                var operation = new EditAlbumOperation(album);

                var result = OperationManager.Instance.ExecuteOperation(operation);

                if (result.IsSuccessful)
                {
                    MessageBox.Show("Uspesno ste editovali!");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(result.Errors.First());
                }
            }
            
        }
    }
}
