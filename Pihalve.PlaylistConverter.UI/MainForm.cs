using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;
using Pihalve.PlaylistConverter.Application.Exceptions;
using Pihalve.PlaylistConverter.Application.Services;
using Pihalve.PlaylistConverter.UI.Properties;

namespace Pihalve.PlaylistConverter.UI
{
    public partial class MainForm : Form
    {
        private IEnumerable<PlaylistItem> _playlistItems;
        private List<PlaylistItem> _spotifyItems = new List<PlaylistItem>();
        private readonly IPlaylistImporter _playlistImporter;
        private readonly ITrackConverter _trackConverter;
        private readonly IRulesFactory _rulesFactory;
        private SearchSettings _searchSettings;

        private enum ViewType { Simple, Advanced }

        public MainForm(IPlaylistImporter playlistImporter, ITrackConverter trackConverter, IRulesFactory rulesFactory)
        {
            _playlistImporter = playlistImporter;
            _trackConverter = trackConverter;
            _rulesFactory = rulesFactory;
            _searchSettings = SettingsFactory.Create(Settings.Default);
            _trackConverter.TrackConvertedEvent += trackConverter_TrackConvertedEvent;
            _trackConverter.TracksConvertedEvent += trackConverter_TracksConvertedEvent;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0} (PROTOTYPE)", AssemblyInformation.Title);
            lblConverting.Visible = false;
            ShowDragMe(false);
            SetupColumns();
            SetView(ViewType.Simple);
        }

        private void SetupColumns()
        {
            lstPlaylist.Columns.Clear();
            lstPlaylist.Columns.Add(CreateColumn("iconColumn", "", 25));
            lstPlaylist.Columns.Add(CreateColumn("artistColumn", "Artist", 180));
            lstPlaylist.Columns.Add(CreateColumn("trackColumn", "Track", 180));
            lstPlaylist.Columns.Add(CreateColumn("albumColumn", "Album", 180));
            lstPlaylist.Columns.Add(CreateColumn("yearColumn", "Year", 60));
            lstPlaylist.Columns.Add(CreateColumn("artistDstColumn", "Artist (Spotify)", 180));
            lstPlaylist.Columns.Add(CreateColumn("trackDstColumn", "Track (Spotify)", 180));
            lstPlaylist.Columns.Add(CreateColumn("albumDstColumn", "Album (Spotify)", 180));
            lstPlaylist.Columns.Add(CreateColumn("yearDstColumn", "Year (Spotify)", 60));
        }

        private ColumnHeader CreateColumn(string name, string text, int width)
        {
            return new ColumnHeader
                {
                    Name = name,
                    Text = text,
                    Width = width,
                    Tag = width.ToString(CultureInfo.InvariantCulture)
                };
        }

        private void btnSelectPlaylist_Click(object sender, EventArgs e)
        {
            try
            {
                EnableActions(false);
                var fileDialog = new OpenFileDialog
                    {
                        Filter = "XML files (*.xml)|*.xml"
                    };

                DialogResult result = fileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    ShowDragMe(false);
                    lblPlaylistFilePath.Text = fileDialog.FileName;
                    lblPlaylistFilePath.Update();
                    ImportPlaylist(fileDialog.FileName);
                }
            }
            catch (InvalidPlaylistFormatException ex)
            {
                ShowErrorMessage("The format of the {0} playlist is invalid or has changed since this application was created.", ex.Message);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("An error occurred.\n" + ex.Message);
            }
            finally
            {
                EnableActions(true);
            }
        }

        private void ImportPlaylist(string filePath)
        {
            _playlistItems = _playlistImporter.Import(filePath).ToList();
            lstPlaylist.Items.Clear();
            foreach (PlaylistItem playlistItem in _playlistItems)
            {
                lstPlaylist.Items.Add(new PlaylistViewItem(playlistItem));
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (_playlistItems == null || !_playlistItems.Any())
                {
                    ShowInfoMessage("A playlist is either not selected or is empty.");
                    return;
                }

                SetConvertionUiState(true);
                ShowDragMe(false);
                Update();
                
                ConvertPlaylist();
            }
            catch(InvalidPlaylistFormatException ex)
            {
                ShowErrorMessage("The format of the {0} playlist is invalid or has changed since this application was created.", ex.Message);
                SetConvertionUiState(false);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("An error occurred.\n" + ex.Message);
                SetConvertionUiState(false);
            }
        }

        private void ConvertPlaylist()
        {
            if (_playlistItems != null)
            {
                ResetConvertionStatus();
                HashSet<BaseRule> rules = _rulesFactory.Create(_searchSettings);
                _spotifyItems = new List<PlaylistItem>();
                //string countryCode = ((Country)cmbCountry.SelectedItem).TwoLetterIsoLanguageName;
                _trackConverter.ConvertAsync(_playlistItems, rules, _searchSettings.FallbackSequence);
            }
        }

        private void trackConverter_TrackConvertedEvent(object sender, TrackConvertionEventArgs e)
        {
            PlaylistItem iTunesItem = e.OriginalTrack;
            PlaylistItem spotifyItem = e.ConvertedTrack;
            var viewItem = (PlaylistViewItem)lstPlaylist.Items.Find(iTunesItem.Id, false).FirstOrDefault();

            if (spotifyItem != null)
            {
                _spotifyItems.Add(spotifyItem);
                if (viewItem != null)
                {
                    viewItem.ImageIndex = 1;
                    viewItem.ArtistDst = spotifyItem.Artist.Name;
                    viewItem.TrackDst = spotifyItem.Track.Name;
                    viewItem.AlbumDst = spotifyItem.Album.Name;
                    viewItem.YearDst = spotifyItem.Album.Year;
                    viewItem.EnsureVisible();
                }
            }
            else
            {
                if (viewItem != null)
                {
                    viewItem.BackColor = Color.Lavender;
                }
            }
        }

        private void trackConverter_TracksConvertedEvent(object sender, EventArgs e)
        {
            SetConvertionUiState(false);
            ShowDragMe(true);
        }

        private void picDragMe_MouseDown(object sender, MouseEventArgs e)
        {
            var convertedPlaylist = new StringBuilder();
            foreach (PlaylistItem playlistItem in _spotifyItems)
            {
                convertedPlaylist.AppendFormat("{0} ", playlistItem.Uri);
            }
            DoDragDrop(convertedPlaylist.ToString(), DragDropEffects.Copy);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SearchSettingsForm();
            DialogResult result = settingsForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _searchSettings = SettingsFactory.Create(Settings.Default);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetView(ViewType.Simple);
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetView(ViewType.Advanced);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }

        private void SetView(ViewType viewType)
        {
            foreach (ColumnHeader column in lstPlaylist.Columns)
            {
                if (column.Name.Contains("Dst"))
                {
                    column.Width = viewType == ViewType.Simple ? 0 : column.Width = Convert.ToInt32(column.Tag);
                }
            }
        }

        private void SetConvertionUiState(bool active)
        {
            EnableActions(!active);
            lblConverting.Visible = active;
        }

        private void ResetConvertionStatus()
        {
            foreach (PlaylistViewItem playlistViewItem in lstPlaylist.Items)
            {
                playlistViewItem.ImageIndex = 0;
            }
        }

        private void ShowDragMe(bool show)
        {
            lblDragMe.Visible = show;
            picDragMe.Visible = show;
        }

        private void EnableActions(bool enable)
        {
            btnSelectPlaylist.Enabled = enable;
            btnConvert.Enabled = enable;
        }

        private void ShowInfoMessage(string text, params object[] args)
        {
            ShowMessage(text, MessageBoxButtons.OK, MessageBoxIcon.Information, args);
        }

        private void ShowErrorMessage(string text, params object[] args)
        {
            ShowMessage(text, MessageBoxButtons.OK, MessageBoxIcon.Error, args);
        }

        private DialogResult ShowMessage(string text, MessageBoxButtons buttons, MessageBoxIcon icon, params object[] args)
        {
            int i = 0;
            foreach (object arg in args)
            {
                string placeholder = string.Format("{{{0}}}", i);
                text = text.Replace(placeholder, arg.ToString());
                i++;
            }
            return MessageBox.Show(this, text, AssemblyInformation.Title, buttons, icon);
        }
    }
}
