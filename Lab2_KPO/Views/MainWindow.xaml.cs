using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using Lab2_KPO.Services;
using org.mariuszgromada.math.mxparser;

namespace Lab2_KPO.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MediaPlayer _clickSoundPlayer = new MediaPlayer();
    public MainWindow()
    {
        InitializeComponent();
    }
   
    
}