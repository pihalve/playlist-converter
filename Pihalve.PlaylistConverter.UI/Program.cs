using System;
using System.Configuration;
using Pihalve.PlaylistConverter.Application.Services;
using Pihalve.PlaylistConverter.Application.Services.Itunes;
using Pihalve.PlaylistConverter.Application.Services.Spotify;
using Pihalve.PlaylistConverter.Application.Services.Web;

namespace Pihalve.PlaylistConverter.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IPlaylistImporter playlistImporter = new ItunesPlaylistImporter();
            IRequestClient requestClient = new RequestClient();
            IRuleProcessor ruleProcessor = new RuleProcessor();
            IRulesFactory rulesFactory = new SpotifyRulesFactory();
            ITokenRetriever tokenRetriever = new SpotifyTokenRetriever(
                ConfigurationManager.AppSettings["accountsServiceUrl"],
                Properties.Settings.Default.ClientId,
                Properties.Settings.Default.ClientSecret,
                requestClient);
            ITrackSearcher trackSearcher = new SpotifyTrackSearcher(
                ConfigurationManager.AppSettings["trackSearchBaseUrl"],
                requestClient,
                ruleProcessor,
                tokenRetriever);
            ITrackConverter trackConverter = new TrackConverter(
                Convert.ToInt32(ConfigurationManager.AppSettings["requestsPerSecond"]),
                trackSearcher);

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm(playlistImporter, trackConverter, rulesFactory));
        }
    }
}
