namespace Pihalve.PlaylistConverter.UI
{
    partial class SearchSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchSettingsForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpFallbackSequence = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lstFallbackSequence = new System.Windows.Forms.CheckedListBox();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIncludeTrack = new System.Windows.Forms.CheckBox();
            this.chkIncludeYear = new System.Windows.Forms.CheckBox();
            this.chkIncludeAlbum = new System.Windows.Forms.CheckBox();
            this.chkIncludeArtist = new System.Windows.Forms.CheckBox();
            this.grpCountry = new System.Windows.Forms.GroupBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.chkCountryInclude = new System.Windows.Forms.CheckBox();
            this.grpProcessors = new System.Windows.Forms.GroupBox();
            this.txtWordsToRemove = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTrackRemoveParentheses = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAlbumRemoveParentheses = new System.Windows.Forms.CheckBox();
            this.chkArtistRemoveParentheses = new System.Windows.Forms.CheckBox();
            this.chkRemoveWords = new System.Windows.Forms.CheckBox();
            this.grpFallbackSequence.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.grpCountry.SuspendLayout();
            this.grpProcessors.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(381, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(300, 431);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grpFallbackSequence
            // 
            this.grpFallbackSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFallbackSequence.Controls.Add(this.label4);
            this.grpFallbackSequence.Controls.Add(this.btnDown);
            this.grpFallbackSequence.Controls.Add(this.btnUp);
            this.grpFallbackSequence.Controls.Add(this.lstFallbackSequence);
            this.grpFallbackSequence.Location = new System.Drawing.Point(12, 256);
            this.grpFallbackSequence.Name = "grpFallbackSequence";
            this.grpFallbackSequence.Size = new System.Drawing.Size(444, 163);
            this.grpFallbackSequence.TabIndex = 2;
            this.grpFallbackSequence.TabStop = false;
            this.grpFallbackSequence.Text = "Fallback sequence";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(325, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 124);
            this.label4.TabIndex = 3;
            this.label4.Text = "Used for defining how to do fallback searches in case a search using the selected" +
    " filters and processors above doesn\'t produce a result.";
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(292, 57);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(26, 26);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(292, 25);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(26, 26);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lstFallbackSequence
            // 
            this.lstFallbackSequence.FormattingEnabled = true;
            this.lstFallbackSequence.Location = new System.Drawing.Point(17, 25);
            this.lstFallbackSequence.Name = "lstFallbackSequence";
            this.lstFallbackSequence.Size = new System.Drawing.Size(269, 124);
            this.lstFallbackSequence.TabIndex = 0;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.label1);
            this.grpFilters.Controls.Add(this.chkIncludeTrack);
            this.grpFilters.Controls.Add(this.chkIncludeYear);
            this.grpFilters.Controls.Add(this.chkIncludeAlbum);
            this.grpFilters.Controls.Add(this.chkIncludeArtist);
            this.grpFilters.Location = new System.Drawing.Point(12, 71);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(221, 179);
            this.grpFilters.TabIndex = 3;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Include in search if available:";
            // 
            // chkIncludeTrack
            // 
            this.chkIncludeTrack.AutoSize = true;
            this.chkIncludeTrack.Location = new System.Drawing.Point(27, 116);
            this.chkIncludeTrack.Name = "chkIncludeTrack";
            this.chkIncludeTrack.Size = new System.Drawing.Size(54, 17);
            this.chkIncludeTrack.TabIndex = 3;
            this.chkIncludeTrack.Text = "Track";
            this.chkIncludeTrack.UseVisualStyleBackColor = true;
            // 
            // chkIncludeYear
            // 
            this.chkIncludeYear.AutoSize = true;
            this.chkIncludeYear.Location = new System.Drawing.Point(27, 93);
            this.chkIncludeYear.Name = "chkIncludeYear";
            this.chkIncludeYear.Size = new System.Drawing.Size(48, 17);
            this.chkIncludeYear.TabIndex = 2;
            this.chkIncludeYear.Text = "Year";
            this.chkIncludeYear.UseVisualStyleBackColor = true;
            // 
            // chkIncludeAlbum
            // 
            this.chkIncludeAlbum.AutoSize = true;
            this.chkIncludeAlbum.Location = new System.Drawing.Point(27, 70);
            this.chkIncludeAlbum.Name = "chkIncludeAlbum";
            this.chkIncludeAlbum.Size = new System.Drawing.Size(55, 17);
            this.chkIncludeAlbum.TabIndex = 1;
            this.chkIncludeAlbum.Text = "Album";
            this.chkIncludeAlbum.UseVisualStyleBackColor = true;
            // 
            // chkIncludeArtist
            // 
            this.chkIncludeArtist.AutoSize = true;
            this.chkIncludeArtist.Location = new System.Drawing.Point(27, 47);
            this.chkIncludeArtist.Name = "chkIncludeArtist";
            this.chkIncludeArtist.Size = new System.Drawing.Size(49, 17);
            this.chkIncludeArtist.TabIndex = 0;
            this.chkIncludeArtist.Text = "Artist";
            this.chkIncludeArtist.UseVisualStyleBackColor = true;
            // 
            // grpCountry
            // 
            this.grpCountry.Controls.Add(this.cmbCountry);
            this.grpCountry.Controls.Add(this.chkCountryInclude);
            this.grpCountry.Location = new System.Drawing.Point(12, 12);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Size = new System.Drawing.Size(444, 53);
            this.grpCountry.TabIndex = 4;
            this.grpCountry.TabStop = false;
            this.grpCountry.Text = "Country";
            // 
            // cmbCountry
            // 
            this.cmbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(195, 21);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(234, 21);
            this.cmbCountry.TabIndex = 6;
            // 
            // chkCountryInclude
            // 
            this.chkCountryInclude.AutoSize = true;
            this.chkCountryInclude.Enabled = false;
            this.chkCountryInclude.Location = new System.Drawing.Point(12, 23);
            this.chkCountryInclude.Name = "chkCountryInclude";
            this.chkCountryInclude.Size = new System.Drawing.Size(177, 17);
            this.chkCountryInclude.TabIndex = 0;
            this.chkCountryInclude.Text = "Include track only if available in:";
            this.chkCountryInclude.UseVisualStyleBackColor = true;
            this.chkCountryInclude.CheckedChanged += new System.EventHandler(this.chkCountryInclude_CheckedChanged);
            // 
            // grpProcessors
            // 
            this.grpProcessors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProcessors.Controls.Add(this.chkRemoveWords);
            this.grpProcessors.Controls.Add(this.txtWordsToRemove);
            this.grpProcessors.Controls.Add(this.label3);
            this.grpProcessors.Controls.Add(this.chkTrackRemoveParentheses);
            this.grpProcessors.Controls.Add(this.label2);
            this.grpProcessors.Controls.Add(this.chkAlbumRemoveParentheses);
            this.grpProcessors.Controls.Add(this.chkArtistRemoveParentheses);
            this.grpProcessors.Location = new System.Drawing.Point(239, 72);
            this.grpProcessors.Name = "grpProcessors";
            this.grpProcessors.Size = new System.Drawing.Size(217, 178);
            this.grpProcessors.TabIndex = 5;
            this.grpProcessors.TabStop = false;
            this.grpProcessors.Text = "Processors";
            // 
            // txtWordsToRemove
            // 
            this.txtWordsToRemove.Location = new System.Drawing.Point(56, 142);
            this.txtWordsToRemove.Name = "txtWordsToRemove";
            this.txtWordsToRemove.Size = new System.Drawing.Size(146, 20);
            this.txtWordsToRemove.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Remove occurrences of these words:";
            // 
            // chkTrackRemoveParentheses
            // 
            this.chkTrackRemoveParentheses.AutoSize = true;
            this.chkTrackRemoveParentheses.Location = new System.Drawing.Point(35, 92);
            this.chkTrackRemoveParentheses.Name = "chkTrackRemoveParentheses";
            this.chkTrackRemoveParentheses.Size = new System.Drawing.Size(54, 17);
            this.chkTrackRemoveParentheses.TabIndex = 8;
            this.chkTrackRemoveParentheses.Text = "Track";
            this.chkTrackRemoveParentheses.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Remove parentheses parts from:";
            // 
            // chkAlbumRemoveParentheses
            // 
            this.chkAlbumRemoveParentheses.AutoSize = true;
            this.chkAlbumRemoveParentheses.Location = new System.Drawing.Point(35, 69);
            this.chkAlbumRemoveParentheses.Name = "chkAlbumRemoveParentheses";
            this.chkAlbumRemoveParentheses.Size = new System.Drawing.Size(55, 17);
            this.chkAlbumRemoveParentheses.TabIndex = 7;
            this.chkAlbumRemoveParentheses.Text = "Album";
            this.chkAlbumRemoveParentheses.UseVisualStyleBackColor = true;
            // 
            // chkArtistRemoveParentheses
            // 
            this.chkArtistRemoveParentheses.AutoSize = true;
            this.chkArtistRemoveParentheses.Location = new System.Drawing.Point(35, 46);
            this.chkArtistRemoveParentheses.Name = "chkArtistRemoveParentheses";
            this.chkArtistRemoveParentheses.Size = new System.Drawing.Size(49, 17);
            this.chkArtistRemoveParentheses.TabIndex = 6;
            this.chkArtistRemoveParentheses.Text = "Artist";
            this.chkArtistRemoveParentheses.UseVisualStyleBackColor = true;
            // 
            // chkRemoveWords
            // 
            this.chkRemoveWords.AutoSize = true;
            this.chkRemoveWords.Location = new System.Drawing.Point(35, 145);
            this.chkRemoveWords.Name = "chkRemoveWords";
            this.chkRemoveWords.Size = new System.Drawing.Size(15, 14);
            this.chkRemoveWords.TabIndex = 12;
            this.chkRemoveWords.UseVisualStyleBackColor = true;
            this.chkRemoveWords.CheckedChanged += new System.EventHandler(this.chkRemoveWords_CheckedChanged);
            // 
            // SearchSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 466);
            this.Controls.Add(this.grpProcessors);
            this.Controls.Add(this.grpCountry);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.grpFallbackSequence);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchSettingsForm";
            this.Text = "Search Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpFallbackSequence.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            this.grpProcessors.ResumeLayout(false);
            this.grpProcessors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpFallbackSequence;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.CheckBox chkIncludeYear;
        private System.Windows.Forms.CheckBox chkIncludeAlbum;
        private System.Windows.Forms.CheckBox chkIncludeArtist;
        private System.Windows.Forms.CheckBox chkIncludeTrack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.CheckBox chkCountryInclude;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.CheckedListBox lstFallbackSequence;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.GroupBox grpProcessors;
        private System.Windows.Forms.CheckBox chkTrackRemoveParentheses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAlbumRemoveParentheses;
        private System.Windows.Forms.CheckBox chkArtistRemoveParentheses;
        private System.Windows.Forms.TextBox txtWordsToRemove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRemoveWords;
    }
}