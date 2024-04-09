using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AllFileConverter
{
    public partial class Form1 : Form
    {

        static string selectFile = null;
        static string InputFilepath = null;
        static string OutputFilepath = null;
        ToolTip toolwindow = new ToolTip();
        static string outputFileExtension = null;
        static List<string> ListOfMultipleSelectedFile = new List<string>();
        static string FileType = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConvertTypeCombobox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Conversion type First !");
                }
                else if (FileEXTComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("please select the output file extension!");
                }
                else
                {
                    Form1 f = new Form1();
                    f.ShowDialogWindow();

                    string FilePath = null;
                    //int ConvertType = -1;
                    string ExtensionName = null;


                    FilePath = Path.GetDirectoryName(selectFile);// using for output file path

                    ExtensionName = FileEXTComboBox.SelectedItem.ToString(); // gettting the extension for output file

                    if (ExtensionName != null)
                    {
                        if (FileType == "single")
                        {
                            InputFileTXTBox.Text = selectFile;
                            InputFilepath = selectFile;   // it has file name selected by user

                            OutputFileTXTBox.Text = FilePath + "\\" + Path.GetFileNameWithoutExtension(selectFile) + ExtensionName;

                            OutputFilepath = FilePath + "\\" + Path.GetFileNameWithoutExtension(selectFile) + ExtensionName;
                            
                        }
                        else if (FileType == "multiple")
                        {

                            if (ListOfMultipleSelectedFile.Count > 1)
                            {
                                InputFileTXTBox.Text = "Multiple Files are selected";
                                OutputFileTXTBox.Text = FilePath + "\\" + "All files\\" + ExtensionName;
                                OutputFilepath = FilePath;
                            }
                            else
                            {
                                InputFileTXTBox.Text = "";
                                InputFileTXTBox.Text = selectFile;
                                OutputFileTXTBox.Text = FilePath + "\\" + Path.GetFileNameWithoutExtension(selectFile) + ExtensionName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowDialogWindow()
        {
            try
            {
                OpenFileDialog FileDialog = new OpenFileDialog();
                FileDialog.InitialDirectory = @"c:\users\desktop";

                if (FileType == "single")
                {

                    FileDialog.ShowDialog();
                    selectFile = FileDialog.FileName;

                }
                else if (FileType == "multiple")
                {

                    FileDialog.Multiselect = true;
                    FileDialog.ShowDialog();
                    ListOfMultipleSelectedFile = FileDialog.FileNames.ToList();

                    selectFile = FileDialog.FileName;

                }
                else
                    MessageBox.Show("please select number of Files radio button !");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectFileTXTBox_MouseHover(object sender, EventArgs e)
        {
            toolwindow.Show(selectFile, this.InputFileTXTBox);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConvertTypeCombobox.Items.Add("PDF Document");
            ConvertTypeCombobox.Items.Add("Word Document");
        }
       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FileType = "single";
            InputFileTXTBox.Clear();
            OutputFileTXTBox.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FileType = "multiple";

            InputFileTXTBox.Clear();
            OutputFileTXTBox.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                InputFileTXTBox.Clear();
                OutputFileTXTBox.Clear();

                int selectedIndex = ConvertTypeCombobox.SelectedIndex;
                FileEXTComboBox.Items.Clear();
                if (selectedIndex > -1)
                {
                    FileEXTComboBox.Text = "--select--";
                    switch (selectedIndex)
                    {
                        case 0:
                            FileEXTComboBox.Items.Add(".pdf");
                            break;
                        case 1:
                            FileEXTComboBox.Items.Add(".docx");
                            break;
                        default:
                            break;
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public void ConvertExcelToPDF(string inputFile,string outputFile)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
                var excelopen = excelapp.Workbooks.Open(inputFile);

                excelapp.MapPaperSize = true;
                excelopen.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputFile);
                excelopen.Close();
                Marshal.ReleaseComObject(excelapp);
                excelapp = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ConvertPPTtoPDF(string inputFile, string outputFile)
        {
            try
            {
                Microsoft.Office.Interop.PowerPoint.Application pptapp = new Microsoft.Office.Interop.PowerPoint.Application();
                pptapp.Activate();

                var pptdocs = pptapp.Presentations;
                var p = pptdocs.Open(inputFile, ReadOnly: MsoTriState.msoFalse, WithWindow: MsoTriState.msoFalse, Untitled: MsoTriState.msoFalse);
                p.ExportAsFixedFormat(outputFile, Microsoft.Office.Interop.PowerPoint.PpFixedFormatType.ppFixedFormatTypePDF);
                pptdocs = null;
                p.Close();
                pptapp.Quit();
                Marshal.ReleaseComObject(pptapp);
                pptapp = null;
                MessageBox.Show("Successfully converted !");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ConvertWordToPDF(string inputFile, string outputFile)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();

                var wordDocument = appWord.Documents.Open(inputFile, ReadOnly: true);
                wordDocument.ExportAsFixedFormat(outputFile, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                wordDocument.Close();
                Marshal.ReleaseComObject(appWord);
                appWord = null;
                MessageBox.Show("Successfully converted !");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ConvertToPDF()
        {
            try
            {
                Form1 f = new Form1();
                if (FileType == "single")
                {
                  
                    if (Path.GetExtension(InputFilepath).ToLower() == ".pdf")
                    {
                        MessageBox.Show("File is already in PDF format please choose different file.");
                    }
                    else
                    {
                        if (Path.GetExtension(InputFilepath).ToLower() == ".xlsx" || Path.GetExtension(InputFilepath).ToLower() == ".xls")
                        {
                            f.ConvertExcelToPDF(InputFilepath, OutputFilepath);

                        }
                        else if(Path.GetExtension(InputFilepath).ToLower() == ".ppt" || Path.GetExtension(InputFilepath).ToLower() == ".pptx")
                        {
                            f.ConvertPPTtoPDF(InputFilepath, OutputFilepath);
                        }
                        else
                        {
                            f.ConvertWordToPDF(InputFilepath, OutputFilepath);
                        }
                    }
                }
                else
                {
                    Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                    if (ListOfMultipleSelectedFile.Any(h=>Path.GetExtension(ListOfMultipleSelectedFile[0]).ToLower() == ".pdf"))
                    {
                        MessageBox.Show("Please choose all files in different format");
                    }
                    else
                    {
                        foreach (var item in ListOfMultipleSelectedFile)
                        {
                            if(Path.GetExtension(item).ToLower()=="ppt" || Path.GetExtension(item).ToLower() == "pptx")
                            {
                                f.ConvertPPTtoPDF(item, OutputFilepath + "\\" + Path.GetFileNameWithoutExtension(item) + outputFileExtension);
                            }
                            else if(Path.GetExtension(item).ToLower() == "xls" || Path.GetExtension(item).ToLower() == "xlsx")
                            {
                                f.ConvertExcelToPDF(item, OutputFilepath + "\\" + Path.GetFileNameWithoutExtension(item) + outputFileExtension);
                            }
                            else
                            {
                                f.ConvertWordToPDF(item, OutputFilepath + "\\" + Path.GetFileNameWithoutExtension(item) + outputFileExtension);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void ConvertToDOCFile()// its working but the content is not save as pdf file have
        {
            Microsoft.Office.Interop.Word.Application wordFile = new Microsoft.Office.Interop.Word.Application();
            var doc = wordFile.Documents.Add();
            try
            {
                var para = doc.Paragraphs.Add();
                doc.Content.Text = File.ReadAllText(InputFilepath, Encoding.UTF8);

                doc.SaveAs2(OutputFilepath, WdSaveFormat.wdFormatDocumentDefault);
                MessageBox.Show("Converted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the document and quit Word application
                if (doc != null)
                {
                    doc.Close();
                    Marshal.ReleaseComObject(doc);
                }
                if (wordFile != null)
                {
                    wordFile.Quit();
                    Marshal.ReleaseComObject(wordFile);
                }
            }

        }
        public void ConvertToExcelFile()
        {

        }

        private void ChangeBTN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            DialogResult dr = FBD.ShowDialog();
            if (!String.IsNullOrWhiteSpace(FBD.SelectedPath))
            {
                if (FileType == "single")
                {
                    OutputFileTXTBox.Text = FBD.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(InputFilepath) + outputFileExtension;
                    OutputFilepath = FBD.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(InputFilepath) + outputFileExtension;
                }
                else
                {
                    OutputFileTXTBox.Text = FBD.SelectedPath + "\\All files"+ outputFileExtension;
                    OutputFilepath = FBD.SelectedPath;
                }
            }
        }

        private void ConvertBTN_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            if (!String.IsNullOrEmpty(InputFileTXTBox.Text) && !String.IsNullOrEmpty(OutputFileTXTBox.Text))
            {
                this.Cursor = Cursors.WaitCursor;

                if (FileEXTComboBox.SelectedItem.ToString().ToLower() == ".pdf")
                {
                    f.ConvertToPDF();

                }
                else if (FileEXTComboBox.SelectedItem.ToString().ToLower() == ".docx")
                {
                    f.ConvertToDOCFile();
                }
            }
            else
            {
                MessageBox.Show("Please select the file First!");
            }
            this.Cursor = Cursors.Default;


        }

        private void FileEXTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputFileExtension = FileEXTComboBox.SelectedItem.ToString().ToLower();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to close the application?", "Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void OutputFileTXTBox_MouseHover(object sender, EventArgs e)
        {
            toolwindow.Show(OutputFileTXTBox.Text, this.OutputFileTXTBox);

        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to close the application?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            InputFileTXTBox.Text = "";
            OutputFileTXTBox.Text = "";
            ConvertTypeCombobox.Items.Clear();
            FileEXTComboBox.Items.Clear();
            ConvertTypeCombobox.Text = "-- Select --";
            ConvertTypeCombobox.Items.Add("PDF Document");
            ConvertTypeCombobox.Items.Add("Word Document");
            FileEXTComboBox.Text = "-- Select --";
        }
    }
}
