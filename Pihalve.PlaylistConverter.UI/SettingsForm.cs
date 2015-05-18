using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.UI.Properties;

namespace Pihalve.PlaylistConverter.UI
{
    public partial class SearchSettingsForm : Form
    {
        public SearchSettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PopulateCountries();
            cmbCountry.Enabled = chkCountryInclude.Checked;

            chkIncludeArtist.Checked = Settings.Default.IncludeArtistInSearch;
            chkIncludeAlbum.Checked = Settings.Default.IncludeAlbumInSearch;
            chkIncludeYear.Checked = Settings.Default.IncludeYearInSearch;
            chkIncludeTrack.Checked = Settings.Default.IncludeTrackInSearch;

            chkArtistRemoveParentheses.Checked = Settings.Default.RemoveParenthesesPartsFromArtist;
            chkAlbumRemoveParentheses.Checked = Settings.Default.RemoveParenthesesPartsFromAlbum;
            chkTrackRemoveParentheses.Checked = Settings.Default.RemoveParenthesesPartsFromTrack;
            chkRemoveWords.Checked = Settings.Default.RemoveWords;
            txtWordsToRemove.Text = Settings.Default.WordsToRemove;
            txtWordsToRemove.Enabled = chkRemoveWords.Checked;

            lstFallbackSequence.ValueMember = "Value";
            lstFallbackSequence.DisplayMember = "Text";
            foreach (string item in Settings.Default.FallbackSequence)
            {
                string[] parts = item.Split(';');
                AddFallbackSequenceItem(new CheckedListItem {Value = parts[0], Checked = bool.Parse(parts[1]), Text = parts[2] });
            }
        }

        private void AddFallbackSequenceItem(CheckedListItem item)
        {
            int idx = lstFallbackSequence.Items.Add(item);
            lstFallbackSequence.SetItemChecked(idx, item.Checked);
        }

        private void chkCountryInclude_CheckedChanged(object sender, EventArgs e)
        {
            cmbCountry.Enabled = chkCountryInclude.Checked;
        }

        private void chkRemoveWords_CheckedChanged(object sender, EventArgs e)
        {
            txtWordsToRemove.Enabled = chkRemoveWords.Checked;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lstFallbackSequence.SelectedItem != null)
            {
                int idx = lstFallbackSequence.SelectedIndex;
                var item = lstFallbackSequence.SelectedItem;
                bool check = lstFallbackSequence.GetItemChecked(idx);
                lstFallbackSequence.Items.RemoveAt(idx);
                int newIdx = idx > 0 ? idx - 1 : 0;
                lstFallbackSequence.Items.Insert(newIdx, item);
                lstFallbackSequence.SelectedItem = item;
                lstFallbackSequence.SetItemChecked(newIdx, check);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lstFallbackSequence.SelectedItem != null)
            {
                int idx = lstFallbackSequence.SelectedIndex;
                var item = lstFallbackSequence.SelectedItem;
                bool check = lstFallbackSequence.GetItemChecked(idx);
                lstFallbackSequence.Items.RemoveAt(idx);
                int newIdx = idx < lstFallbackSequence.Items.Count ? idx + 1 : lstFallbackSequence.Items.Count;
                lstFallbackSequence.Items.Insert(newIdx, item);
                lstFallbackSequence.SelectedItem = item;
                lstFallbackSequence.SetItemChecked(newIdx, check);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Default.IncludeArtistInSearch = chkIncludeArtist.Checked;
            Settings.Default.IncludeAlbumInSearch = chkIncludeAlbum.Checked;
            Settings.Default.IncludeYearInSearch = chkIncludeYear.Checked;
            Settings.Default.IncludeTrackInSearch = chkIncludeTrack.Checked;

            Settings.Default.RemoveParenthesesPartsFromArtist = chkArtistRemoveParentheses.Checked;
            Settings.Default.RemoveParenthesesPartsFromAlbum = chkAlbumRemoveParentheses.Checked;
            Settings.Default.RemoveParenthesesPartsFromTrack = chkTrackRemoveParentheses.Checked;
            Settings.Default.RemoveWords = chkRemoveWords.Checked;
            Settings.Default.WordsToRemove = txtWordsToRemove.Text;

            var fallbackSequenceItems = new StringCollection();
            foreach (CheckedListItem listItem in lstFallbackSequence.Items)
            {
                string item = string.Format("{0};{1};{2}",
                    listItem.Value,
                    lstFallbackSequence.GetItemChecked(lstFallbackSequence.Items.IndexOf(listItem)),
                    listItem.Text);
                fallbackSequenceItems.Add(item);
            }
            Settings.Default.FallbackSequence = fallbackSequenceItems;

            Settings.Default.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void PopulateCountries()
        {
            var countries = Country.Countries.OrderBy(x => x.Name);
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "TwoLetterISOLanguageName";
            cmbCountry.Items.AddRange(countries.Select(x => (object)x).ToArray());
            Country currentCountry = Country.GetCurrentCultureCountry();
            cmbCountry.SelectedItem = countries.FirstOrDefault(x => x.TwoLetterIsoLanguageName == currentCountry.TwoLetterIsoLanguageName);
        }
    }
}
