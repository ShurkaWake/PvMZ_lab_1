using System.Web;

namespace Client
{
    public partial class Form1 : Form
    {
        private static HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://172.25.73.149:4612/brackets"),
        };
        public Form1()
        {
            InitializeComponent();
        }

        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["text"] = InputTextBox.Text;

            // Build the full request URI with query parameters
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Query = query.ToString()
            };

            // Send the GET request
            var response = await _httpClient.GetAsync(uriBuilder.Uri);

            MessageBox.Show(await response.Content.ReadAsStringAsync());
        }
    }
}