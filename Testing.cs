using AC_Image.Services.Imgur;
using AC_Image.Services.OpenAI;
using AC_Image.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AC_Image
{
    public partial class Testing : Form
    {
        TextAIService textServices = new();

        Services.Imgur.ImageServices imageServices = new Services.Imgur.ImageServices();

        public Testing()
        {
            InitializeComponent();
        }

        private void Testing_Load(object sender, EventArgs e)
        {
            string testingUrl = "https://i.imgur.com/JTTbzRl.jpg";

            txtGenerateCaptionUrl.Text = testingUrl;
            txtGenerateDescriptionUrl.Text= testingUrl;
            txtGenerateKeywordUrl.Text = testingUrl;
            txtGenerateHashtagUrl.Text = testingUrl;
            txtGenerateLabelsUrl.Text = testingUrl;
            txtTesting.Text= "JTsadada Rlss";
        }

        private async void btnGenerateCaption_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;

            var result = await Task.Run(() => textServices.GetCaption(txtGenerateCaptionUrl.Text));

            if (result != null) {
                string resultContent = result.Trim().Replace("\"", "");

                rtGenerateCaptionResult.Clear();
                rtGenerateCaptionResult.Text = resultContent; 
            
            }
            progressBar1.Visible = false;
        }

        private async void btnGenerateDescription_Click(object sender, EventArgs e)
        {
            progressBar2.Visible = true;

            var result = await Task.Run(() => textServices.GetDescription(txtGenerateDescriptionUrl.Text));

            if (result != null)
            {
                string resultContent = result.Trim().Replace("\"", "");

                rtGenerateDescriptionResult.Clear();
                rtGenerateDescriptionResult.Text = resultContent;

            }
            progressBar2.Visible = false;
        }

        private async void btnGenerateKeyword_Click(object sender, EventArgs e)
        {
            progressBar3.Visible = true;

            var result = await Task.Run(() => textServices.GetKeywords(txtGenerateKeywordUrl.Text));

            if (result != null)
            {
                string resultContent = result.Trim().Replace("\"", "");

                rtGenerateKeywordResult.Clear();
                rtGenerateKeywordResult.Text = resultContent + "\n\n";
                rtGenerateKeywordResult.Text += new StringService().Convert2CapitalEachWord(resultContent);

            }
            progressBar3.Visible = false;
        }

        private async void btnGenerateHashtag_Click(object sender, EventArgs e)
        {
            progressBar4.Visible = true;

            var result = await Task.Run(() => textServices.GetKeywords(txtGenerateHashtagUrl.Text));

            if (result != null)
            {
                string resultContent = result.Trim().Replace("\"", "");

                rtGenerateHashtagResult.Clear();
                rtGenerateHashtagResult.Text = resultContent + "\n\n";
                rtGenerateHashtagResult.Text += new StringService().string2Hashtag(resultContent);

            }
            progressBar4.Visible = false;
        }

        private async void btnGenerateLabels_Click(object sender, EventArgs e)
        {
            progressBar5.Visible = true;

            var result = await Task.Run(() => textServices.GetKeywords(txtGenerateLabelsUrl.Text));

            if (result != null)
            {
                string resultContent = result.Trim().Replace("\"", "");

                rtGenerateLabelsResult.Clear();
                rtGenerateLabelsResult.Text = resultContent + "\n\n";
                rtGenerateLabelsResult.Text += new StringService().Convert2CapitalEachWord(resultContent); 

            }
            progressBar5.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var serviceRunning = await imageServices.getImage(txtTesting.Text);

                if (serviceRunning.success)
                {
                    var result = serviceRunning.data;

                    string text = result.title + "\n";
                    text += $"{result.width} x {result.height} \n";
                    text += $"{result.link} \n";


                    rtbTesting.Text = text;
                }

                throw new Exception(serviceRunning.message);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
    }
}
