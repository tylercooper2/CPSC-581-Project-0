using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers; 

namespace Project_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        private static System.Timers.Timer fireTimer;
        private static System.Timers.Timer steakTimer;
        private static System.Timers.Timer waitTimer; 
        private  bool fireColor = true;
        private  bool fireNumber = true;
        private int time = 0;
        private bool finishedCooking = false; 

        public MainWindow()
        {
            InitializeComponent();

            SetTimer();


        }

        public void SetTimer()
        {
            fireTimer = new System.Timers.Timer(1000);

            fireTimer.Elapsed += OnTimedEvent;
            fireTimer.AutoReset = true;
            fireTimer.Enabled = true;

            steakTimer = new System.Timers.Timer(5000);

            steakTimer.Elapsed += StartCooking;
            steakTimer.AutoReset = true;
            steakTimer.Enabled = true;

            

        }


        private void StartCooking(Object source, ElapsedEventArgs e)
        {

            this.time++;
            //Change the steak color every 5 seconds
            if(time == 1)
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Steak1.Visibility = Visibility.Hidden;
                    this.Steak2.Visibility = Visibility.Visible;

                });
            }

            else if (time == 2)
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Steak2.Visibility = Visibility.Hidden;
                    this.Steak3.Visibility = Visibility.Visible;

                });
            }

            else if (time == 3)
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.Steak3.Visibility = Visibility.Hidden;
                    this.Steak4.Visibility = Visibility.Visible;

                });
            }


        }

        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Changing the fire every second
            if (fireNumber && fireColor)
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.RedFire1.Visibility = Visibility.Hidden;
                    this.RedFire2.Visibility = Visibility.Visible;
                    fireNumber = false;
                });



            }

            else if (fireNumber && !fireColor)
            {

                this.Dispatcher.Invoke(() =>
                {

                    this.RedFire1.Visibility = Visibility.Visible;
                    this.RedFire2.Visibility = Visibility.Hidden;
                    fireNumber = false;

                }); 

            }

            else if (!fireNumber && fireColor)
            {

                this.Dispatcher.Invoke(() =>
                {

                    this.YellowFire1.Visibility = Visibility.Hidden;
                    this.YellowFire2.Visibility = Visibility.Visible;
                    fireNumber = true;
                    fireColor = false;
                });
            }
            else
            {

                this.Dispatcher.Invoke(() =>
                {

                    this.YellowFire1.Visibility = Visibility.Visible;
                    this.YellowFire2.Visibility = Visibility.Hidden;
                    fireNumber = true;
                    fireColor = true;

                });
            }
            
          


        }

        private void onClick(object sender, MouseButtonEventArgs e)
        {
            //Reset steak on click 
            steakTimer.Stop();
            this.time = 0;

            
            /*
                finishedCooking = false;

                this.Steak1.Visibility = Visibility.Visible;
                this.Steak2.Visibility = Visibility.Hidden;
                this.Steak3.Visibility = Visibility.Hidden;
                this.Steak4.Visibility = Visibility.Hidden;
            
    
            */

            

        }
    }
}
