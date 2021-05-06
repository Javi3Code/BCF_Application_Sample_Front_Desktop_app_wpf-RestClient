using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace JPA_Porra_Burgos.View
{
    /// <summary>
    /// 
    /// Clase vinculada a la ventana de inicio. Simplemente es una ventana de carga,
    /// simulando una especie de arranque costoso, el objetivo de esto dar una pequeña bienvenida 
    /// al usuario con una foto nostálgica en portada.
    /// 
    /// </summary>
    public partial class Login : Window
    {

        private const char PERCENT = '%';
        private const string EMPTY = "";

        /// <summary>
        /// 
        /// Constructor, se inicializan los componentes.
        /// 
        /// </summary>
        public Login() => InitializeComponent();

        /// <summary>
        /// 
        /// Evento de arranque. Se ejecuta en background un proceso para cargar un ProgressBar y un label que
        /// indica el porcentaje.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowLoadEvent(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += DoWork;
            worker.ProgressChanged += ProgressChanged;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// 
        /// Evento añadido al objeto BackgroundWorker que se encarga de realizar la tarea en Background.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            for (int i = 0; i <= 100; i++)
            {
                worker.ReportProgress(i);
                Thread.Sleep(15);
            }
            Thread.Sleep(10);
            worker.ReportProgress(-1);
        }

        /// <summary>
        /// 
        /// Evento que se ejecuta cuando ha cambiado el progreso del BackgroundWorker, modificando los
        /// valores de los atributos de los componentes que manipulamos.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progressPercentage = e.ProgressPercentage;
            if (progressPercentage >= 0)
            {
                progressInit.Value = progressPercentage;
                percentage.Content = progressPercentage + EMPTY + PERCENT;
            }
            else { Thread.Sleep(1700); new PrincipalMenu().Show(); Close(); }
        }
    }
}
