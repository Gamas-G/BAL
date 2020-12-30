using System;
using System.IO;
using System.Data;
using System.Text;
using ExcelDataReader;
using System.Diagnostics;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using Code7248.word_reader;
using System.Threading.Tasks;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;

namespace BAL
{
    public partial class Form1 : Form
    {
        #region Variables
        private string findWord;
        private string[][] matrizRam = new string[4][];
        private string pathGeneric = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA\\";

        private int contArchivoRelac = 0;

        delegate void delegateControl(Control control, string inf);
        

        private DriveInfo[] allDrives;
        private delegateControl control;
        private Process proceso = new Process();
        #endregion

        public Form1()
        {
            InitializeComponent();

            control = new delegateControl(SelectControl);
        }


        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (textBoxPalabra.Text == "") return;

            Buscar.Enabled = false;
            ButtonLimpiar.Enabled = false;
            ButtonSalir.Enabled = false;
            labelContador.Text = contArchivoRelac.ToString();
            GetDrives();

            await Start();

            groupBoxInfProceso.Visible = false;
            Buscar.Enabled = true;
            ButtonLimpiar.Enabled = true;
            ButtonSalir.Enabled = true;
        }


        private async Task Start()
        {
            groupBoxInfProceso.Visible = true;
            findWord = CleanCharacteres(textBoxPalabra.Text).ToLower();//Limpia y pone en minusculas la palabra ingresada
            foreach ( var unidadMemoria in allDrives )
            {
                string unidM = unidadMemoria.Name.Substring( 0, 1 );
                //Entra a un bucle de las unidades
                //Si una unidad, USB por ejemplo es retirado, se visualiza en el listBox
                if ( !unidadMemoria.IsReady ) { listBoxAdvertencias.Items.Add("Unidad \"" + unidadMemoria.Name + "\" no detectada"); continue; }
                //Si todo esta correcto para a visualizar y a preparar para los metodos
                //Aqui requiere de una carpeta y valida que si no existe la crea
                if ( !Directory.Exists( Environment.GetFolderPath( Environment.SpecialFolder.UserProfile ) + "\\GUAPA" ) ) { Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA"); }
                await GetPaths( unidM );//Aqui obtiene las rutas de la unidadMemoria en turno
                await FindFolder(unidM);//Incia el Metodo mas importante. Aqui es donde hace todo el trabajo de las coincidencias
            }
        }

        private async Task GetPaths(string ruta)
        {
            await Task.Run(() =>
            {
                //COMANDOS PARA LA EXTRACCIÓN DE RUTAS DE ACCESO, OMITIENDO LAS QUE NO DAN ACCESO
                string comandoForfilesTXT  = "FORFILES /P " + ruta + ": /S /M \"*.txt\" /C \"cmd /c echo @PATH\" >" + pathGeneric + "pathsTXT.txt";
                string comandoForfilesPDF  = "FORFILES /P " + ruta + ": /S /M \"*.pdf\" /C \"cmd /c echo @PATH\" >" + pathGeneric + "pathsPDF.txt";
                string comandoForfilesWORD = "FORFILES /P " + ruta + ": /S /M \"*.docx\" /C \"cmd /c echo @PATH\" >" + pathGeneric + "pathsWORD.txt";
                string comandoForfilesXLSX = "FORFILES /P " + ruta + ": /S /M \"*.xlsx\" /C \"cmd /c echo @PATH\" >" + pathGeneric + "pathsXLSX.txt";
                string limpiarCmd = "cd /";
                //INICIALIZACION DE UN PROCESS
                Process test = new Process();//LA CLASE PROCESS AYUDA A EJECUTAR PROCESOS, EN ESTE CASO la consola CMD que s donde le metemos comandos, los cuales estan estruxturados arriba
                test.StartInfo.FileName = "cmd.exe";//ejecutando el cmd
                test.StartInfo.RedirectStandardInput = true;//LE PERMITIMOS INGRESAR LINEAS DE COMANDOS
                test.StartInfo.RedirectStandardOutput = true;//LE DESACTIVAMOS LA VISUALIZACION

                test.StartInfo.UseShellExecute = false;
                test.StartInfo.CreateNoWindow = true;//OCULTAMOS LA VENTANA POR COMODIDAD

                test.StartInfo.Arguments = limpiarCmd;
                try
                {
                    test.Start();////INICIALIZA

                    //Se limpia la ruta predefinida del ejecutable
                    //Incresa los comandos
                    test.StandardInput.WriteLine(limpiarCmd);
                    test.StandardInput.Flush();

                    //Se cambia el chcp
                    test.StandardInput.WriteLine("chcp 65001");
                    test.StandardInput.Flush();

                    //Y se ingresa la ruta predefinida
                    test.StandardInput.WriteLine("cd " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                    test.StandardInput.Flush();

                    //Una vez corregido todo se ingresa el comando de busqueda TXT
                    test.StandardInput.WriteLine(comandoForfilesTXT);
                    test.StandardInput.Flush();

                    //Una vez corregido todo se ingresa el comando de busqueda PDF
                    test.StandardInput.WriteLine(comandoForfilesPDF);
                    test.StandardInput.Flush();

                    //Una vez corregido todo se ingresa el comando de busqueda WORD
                    test.StandardInput.WriteLine(comandoForfilesWORD);
                    test.StandardInput.Flush();

                    //Una vez corregido todo se ingresa el comando de busqueda XLSX
                    test.StandardInput.WriteLine(comandoForfilesXLSX);
                    test.StandardInput.Flush();

                    test.StandardInput.Close();
                    test.WaitForExit();

                    //Almacena las rutas de los archivos (txt, pdf, docx y xls) dentro de la matriz
                    matrizRam[0] = File.ReadAllLines(pathGeneric + "pathsTXT.txt", Encoding.UTF8);
                    matrizRam[1] = File.ReadAllLines(pathGeneric + "pathsPDF.txt", Encoding.UTF8);
                    matrizRam[2] = File.ReadAllLines(pathGeneric + "pathsWORD.txt", Encoding.UTF8);
                    matrizRam[3] = File.ReadAllLines(pathGeneric + "pathsXLSX.txt", Encoding.UTF8);

                    //Una vez en los erreglos pasa a eliminar los TXT
                    File.Delete(pathGeneric + "pathsTXT.txt");
                    File.Delete(pathGeneric + "pathsPDF.txt");
                    File.Delete(pathGeneric + "pathsWORD.txt");
                    File.Delete(pathGeneric + "pathsXLSX.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un problema al extraer las rutas");
                    return;
                }

            }).ContinueWith((task1) => { CleanPaths(); });

        }

        private void  CleanPaths() //Eliminamos las comillas de todas las rutas
        {
            for (int i = 0; i < matrizRam.Length; i++)
            {
                for (int j = 1; j < matrizRam[i].Length; j++)
                {
                    matrizRam[i][j] = matrizRam[i][j].Trim('"');
                }
            }
        }

        private async Task FindFolder( string driv )
        {
            labelMensjaeEspere.Visible = false;
            labelTrabajandoSobreUni.Visible = true;
            labelUnidad.Visible = true;
            labelUnidad.Text = driv;

            ColumnPath.Visible = true;
            ColumnInf.Visible = true;
            ColumnCreacion.Visible = true;
            ColumnLastModif.Visible = true;
            ColumnType.Visible = true;

            progressBarArchivos.Style = ProgressBarStyle.Marquee;
            progressBarArchivos.Visible = true;
            FileInfo rutaArchivo = null;

            dataGridViewArchivos.Rows.Add("RESULTADO(S) de \"" + textBoxPalabra.Text + "\" Sombre la Unidad \"" + driv + "\"", "RESULTADO(S)", "RESULTADO(S)", "RESULTADO(S)");

            for (int i = 0; i < matrizRam.Length; i++)
            {
                for (int j = 1; j < matrizRam[i].Length; j++)
                {
                    rutaArchivo = new FileInfo(matrizRam[i][j]);
                    await Working(rutaArchivo);

                    labelContador.Text = contArchivoRelac.ToString();
                }
            }

            File.Delete( pathGeneric + "csvFile.csv" );
            File.Delete( pathGeneric + "PdfFile.txt" );
            File.Delete( pathGeneric + "WordFile.txt" );

            progressBarArchivos.Style = ProgressBarStyle.Blocks;
            progressBarArchivos.Visible = false;

            labelMensjaeEspere.Visible = true;
            labelTrabajandoSobreUni.Visible = false;
            labelUnidad.Visible = false;
        }

        private async Task Working(FileInfo infFile)
        {
            string archivo = CleanCharacteres(infFile.Name).ToLower();
            //Working incia con un switch y dependiendo del archivo  toma las rutas ya preparadas
            switch (infFile.Extension)
            {
                case ".txt":

                    var (confirmationTxt, contentTxt) = await ValidateInTxt(infFile.FullName);
                    if (archivo.Contains(this.findWord) || confirmationTxt)
                    {
                        if (infFile.Exists)
                        {
                            contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentTxt, infFile.CreationTime, infFile.LastAccessTime, "TXT");
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "Verifique el archivo, Archivo inexistente...Posible eliminación", "Sin resultados...", "Sin resultados....", "TXT");
                        }
                    }
                    break;
                case ".pdf":

                    var (confirmationPdf, contentPdf) = await ValidateInPdf(infFile.FullName);
                    if (archivo.Contains(this.findWord) || confirmationPdf)
                    {
                        if (infFile.Exists)
                        {
                            this.contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentPdf, infFile.CreationTime, infFile.LastAccessTime, "PDF");
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "verifique el archivo, archivo inexistente...posible eliminación", "Sin resultados...", "sin resultados...", "PDF");
                        }
                    }
                    break;
                case ".docx":

                    var (confirmationWord, contentWord) = await ValidateInWord(infFile.FullName);
                    if (archivo.Contains(this.findWord) || confirmationWord)
                    {
                        if (infFile.Exists)
                        {
                            this.contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentWord, infFile.CreationTime, infFile.LastAccessTime, "WORD");
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "verifique el archivo, archivo inexistente...posible eliminación", "Sin resultados...", "sin resultados...", "WORD");
                        }
                    }
                    break;
                case ".xlsx":

                    var (confirmationExcel, contentExcel) = await ValidateInExcel(infFile.FullName);
                    if (archivo.Contains(this.findWord) || confirmationExcel)
                    {
                        if (infFile.Exists)
                        {
                            this.contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentExcel, infFile.CreationTime, infFile.LastAccessTime, "EXCEL"); ;
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "verifique el archivo, archivo inexistente...posible eliminación", "Sin resultados", "sin resultados...", "EXCEL");
                        }
                    }
                    break;
            }
        }

        #region Metodos para los Archivos
        //Sección de Archivos Txt*************************************************************************************************************************************
        private async Task<(bool confirmationTxt, string contentTxt)> ValidateInTxt( string pathFileTxt )
        {
            //METODO DONDE SE VALIDA Y SE EXTRAE LA INFORMACION DE LOS ARCHIVOS TXT
            var tupleValores = ( confirmationTxt: false, contentTxt: "Sin resultados" );
            string[] contentFileTxt;

            contentFileTxt = await GetInfoInsideFile( pathFileTxt );

            if ( contentFileTxt == null ) { return tupleValores; }

            tupleValores = await ReadFile( contentFileTxt );

            return tupleValores;
        }
        //Final de Sección de Archivos Txt******************************************************************************************************************************


        //Sección de Archivos Pdf***************************************************************************************************************************************
        private async Task<( bool confirmationPdf, string contentPdf )> ValidateInPdf( string pathFilePdf )
        {
            //METODO DONDE VALIDFA Y EXTRAE LA INFORMACION DE LOS ARCHIVOS PDF
            var tupleValores = ( confirmationTxt: false, contentTxt: "Sin resultados" );
            string[] contentFilePdf;

            if( !await ConvertPdfToFile(pathFilePdf) ) { return tupleValores; }

            contentFilePdf =  await GetInfoInsideFile(pathGeneric + "PdfFile.txt");

            if (contentFilePdf == null) { return tupleValores; }

            tupleValores = await ReadFile(contentFilePdf);

            return tupleValores;
        }

        private async Task<bool> ConvertPdfToFile(string pathFilePdf)
        {
            bool resp = false;
            string s;
            string strText = string.Empty; ;
            await Task.Run(() =>
            {
                try
                {

                    PdfReader reader = new PdfReader(pathFilePdf);
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));

                        strText = strText + s;
                    }
                    reader.Close();
                    File.WriteAllText(pathGeneric + "PdfFile.txt", strText, Encoding.UTF8);
                    resp = true;
                }
                catch (Exception)
                {
                    listBoxAdvertencias.BeginInvoke(control, listBoxAdvertencias, pathFilePdf);
                }
            });
            return resp;
        }
        //Final de Sección de Archivos Pdf******************************************************************************************************************************

        
        //Sección de Archivos Word**************************************************************************************************************************************
        private async Task<(bool confimationWord, string contentWord)> ValidateInWord( string pathFileWord )
        {
            //Metodo donde valida y extrae la informacion de los Archivos DOCX
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            string[] contentFileWord;

            if (!await ConvertWordtoFile(pathFileWord)) { return tupleValores; };

            contentFileWord = await GetInfoInsideFile(pathGeneric + "WordFile.txt");

            if (contentFileWord == null) { return tupleValores; }

            tupleValores = await ReadFile(contentFileWord);

            return tupleValores;
        }

        private async Task<bool> ConvertWordtoFile(string pathFileWord)
        {
            string guapo;
            bool resp = false;
            await Task.Run(() =>
            {
                try
                {
                    TextExtractor ext = new TextExtractor(pathFileWord);
                    guapo = ext.ExtractText();

                    File.WriteAllText(pathGeneric + "WordFile.txt", guapo, Encoding.UTF8);
                    resp = true;
                }
                catch (Exception)
                {
                    listBoxAdvertencias.BeginInvoke(control, listBoxAdvertencias, pathFileWord);
                }
            });
            return resp;
        }
        //Final De Sección de Archivos Word****************************************************************************************************************************************

        
        //Sección de Arcvhios Excel***********************************************************************************************************************************************
        private async Task<(bool confirmationExcel, string contentExcel)> ValidateInExcel(string pathFileExcel)
        {
            //Metodo del Excel, aqui primero manda a conversion una vez si la conversion es exitosa, pasa a la extraccion de las palabras para validar
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            string[] contentFileXlsx;

            if (!await ConvertExcel(pathFileExcel)) { return tupleValores; }

            contentFileXlsx = await GetInfoInsideFile( pathGeneric + "csvFile.csv" );

            if (contentFileXlsx == null) { return tupleValores; }

            tupleValores = await ReadFile(contentFileXlsx);
            
            return tupleValores;
        }

        private async Task<bool> ConvertExcel(string path)
        {
            //Conversion de los archivos Excel a Txt, donde se lee linea por linea implementando multiples metodos para la extraccion de la palabra
            bool resp = false;
            string csvData = "";
            await Task.Run(()=> {

                try
                {
                    FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;
                    if (System.IO.Path.GetExtension(path).ToUpper() == ".XLS")
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    DataSet result = excelReader.AsDataSet();
                    excelReader.Close();
                    int n = result.Tables.Count;
                    for (int i = 0; i < n; i++)
                    {
                        result.Tables[i].TableName.ToString();
                        int row_no = 0;
                        while (row_no < result.Tables[i].Rows.Count)
                        {
                            for (int j = 0; j < result.Tables[i].Columns.Count; j++)
                            {
                                csvData += result.Tables[i].Rows[row_no][j].ToString() + ",";
                            }
                            row_no++;
                            csvData += "\n";
                        }
                    }

                    StreamWriter csv = new StreamWriter( pathGeneric + "CsvFile.csv" );

                    csv.Write(csvData);
                    csv.Close();
                    resp = true;
                }
                catch (Exception)
                {
                    listBoxAdvertencias.BeginInvoke(control, listBoxAdvertencias, path);
                }

            });
            return resp;
        }
        //Final De Sección de Archivos de Excel********************************************************************************************************************************
        #endregion

        private async Task<(bool confirmationPdf, string contentPdf)> ReadFile(string[] info)
        {
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            await Task.Run(() =>
            {
                foreach (var item in info)
                {
                    info = item.Split(new char[] { ',', '.', '_', '/', '-', ';', ':', '\\', '\n' });
                    foreach (var item2 in info)
                    {
                        string PIV = CleanCharacteres(item2).ToLower();

                        if (PIV.Contains(this.findWord))
                        {
                            tupleValores.confirmationTxt = true;
                            tupleValores.contentTxt = item2;
                            break;
                        }
                    }
                }
            });
            return tupleValores;
        }

        private async Task<string[]> GetInfoInsideFile(string pathFile)
        {
            //Metodo donde se extrae la informacion de los archivos TXT y si ocurre un error se muestra en el listBox de advertencias
            string[] contentFile = null;

            await Task.Run(() =>
            {
                try
                {
                    contentFile = File.ReadAllLines(pathFile, Encoding.UTF8);

                }
                catch (Exception)
                {
                    listBoxAdvertencias.BeginInvoke(control, listBoxAdvertencias, pathFile);
                }
            });
            return contentFile;
        }

        private void SelectControl(Control control, string text)
        {
            if (control is ListBox)
            {
                if (text != pathGeneric + "pathsTXT.txt")
                {
                    listBoxAdvertencias.Items.Add(text);
                }
            }
        }

        private string CleanCharacteres(string nombreArchivo)
        {
            //Metodo donde limpia todas las tildes y ñ de los string obtrenidos de los archivos
            string palbLimpia = string.Empty;
            string[] palCortada = nombreArchivo.Split(' '); //Corta en las separaciones ya que es una palabra completa
            foreach (var item in palCortada)
            {
                try//Encerramos en un try por si surge un error y podremos observarlo en nuestro panel de errores
                {
                    string textoNormalizado = item.Normalize(NormalizationForm.FormD);
                    string textoSinAcento = Regex.Replace(textoNormalizado, @"[^0-9A-Za-z]", "");
                    palbLimpia = palbLimpia + textoSinAcento;
                }
                catch (Exception)
                {
                    return palbLimpia = string.Empty;
                }
            }
            return palbLimpia;
        }

        private void GetDrives() { allDrives = DriveInfo.GetDrives(); NumUnidades.Text = allDrives.Length.ToString(); }//Metodo extracción de unidades de almacenamientos en el equipo

        private void dataGridViewArchivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Aqui se abre el archivo que se encuentra localmente
            string data = dataGridViewArchivos.SelectedCells[0].EditedFormattedValue.ToString();
            if (!(data.Trim() == "" || data.Contains("RESULTADO")))
            {
                FileInfo file = new FileInfo(data);
                if (file.Exists)
                {
                    proceso.StartInfo.FileName = data;
                    proceso.Start();
                }
                else
                {
                    //this.contadorAdventerncias++;
                    listBoxAdvertencias.Items.Add("EL archivo " + data + " no existe");
                    //labelContAdvertencias.Text = this.contadorAdventerncias.ToString();
                }
            }
        }

        private void ButtonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            //Evento donde elimina el contenido del dataGridView, ListBox y resetea los contadores de archivos
            this.contArchivoRelac = 0;

            if (!(dataGridViewArchivos == null))
            {
                dataGridViewArchivos.Rows.Clear();
            }
            if (!(labelContador == null))
            {
                labelContador.Text = this.contArchivoRelac.ToString();
            }
            if (!(listBoxAdvertencias == null))
            {
                listBoxAdvertencias.Items.Clear();
            }

            ColumnPath.Visible = false;
            ColumnInf.Visible = false;
            ColumnLastModif.Visible = false;
            ColumnCreacion.Visible = false;
            ColumnType.Visible = false;
        }
    }
}
