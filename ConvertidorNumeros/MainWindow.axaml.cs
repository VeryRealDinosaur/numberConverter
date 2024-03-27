using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using AvaloniaGif;

namespace ConvertidorNumeros;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Width = 800;
        this.Height = 600;

        Background = this.FindControl<GifImage>("Background");
        Background.Width = this.Width; // Set GIF width to match window
        Background.Height = this.Height; // Set GIF height to match window
    }


    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        resultLabel = this.FindControl<Label>("resultLabel");
        Dropdown = this.FindControl<ComboBox>("Dropdown");
        BtnGo = this.FindControl<Button>("BtnGo");
        Entry = this.FindControl<TextBox>("Entry");
    }

    private void Cal_OnClick_(object? sender, RoutedEventArgs e)
    {
        int selectedItem = Dropdown.SelectedIndex;
        Entry.BorderBrush = new SolidColorBrush(Color.FromRgb(69,158,47));

        if (float.TryParse(Entry.Text, out float number))
        {
            if (selectedItem == 0)
            {
                if (number % 1 == 0)
                {
                    int intNumber = Convert.ToInt32(number);
                    resultLabel.Content =
                        $"El numero {number} en binario es : {Convert.ToString(intNumber, 2).PadLeft(8, '0')}";
                }
                else
                {
                    float absFloat = Math.Abs(number);
                    int integerPart = (int)absFloat;
                    float fractionalPart = absFloat - integerPart;
                    string integerBinary = Convert.ToString(integerPart, 2).PadLeft(8, '0');

                    string fractionalBinary = "";
                    for (int i = 0; i < 8; i++)
                    {
                        fractionalPart *= 2;
                        fractionalBinary += (int)fractionalPart % 2;
                        if (fractionalPart == 0)
                        {
                            break;
                        }
                    }

                    resultLabel.Content = $"El número {number} en binario es: {integerBinary}.{fractionalBinary}";
                }
            }

            else if (selectedItem == 1)
            {
                if (number % 1 == 0)
                {
                    int intNumber = Convert.ToInt32(number);
                    resultLabel.Content = $"El numero {number} en octal es : {Convert.ToString(intNumber, 8)}";
                }
                else
                {
                    float absFloat = Math.Abs(number);
                    int integerPart = (int)absFloat;
                    float fractionalPart = absFloat - integerPart;
                    string integerOctal = Convert.ToString(integerPart, 8);

                    string fractionalOctal = "";
                    for (int i = 0; i < 8; i++)
                    {
                        fractionalPart *= 8;
                        fractionalOctal += (int)fractionalPart % 8;
                        if (fractionalPart == 0)
                        {
                            break;
                        }
                    }

                    resultLabel.Content = $"El número {number} en octal es: {integerOctal}.{fractionalOctal}";
                }
            }

            else if (selectedItem == 2)
            {
                if (number % 1 == 0)
                {
                    int intNumber = Convert.ToInt32(number);
                    resultLabel.Content = $"El numero {number} en hexadecimal es : {intNumber.ToString("X")}";
                }
                else
                {
                    float absFloat = Math.Abs(number);
                    int integerPart = (int)absFloat;
                    float fractionalPart = absFloat - integerPart;

                    string hexIntegerPart = integerPart.ToString("X");

                    int accuracy = 8;
                    string hexFractionalPart = "";

                    while (fractionalPart != 0 && accuracy > 0)
                    {
                        fractionalPart *= 16;
                        int integerPartOfFractionalPart = (int)fractionalPart;
                        hexFractionalPart += integerPartOfFractionalPart.ToString("X");
                        fractionalPart -= integerPartOfFractionalPart;
                        accuracy--;
                    }

                    resultLabel.Content = $"El número {number} en hexadecimal es: {hexIntegerPart}.{hexFractionalPart}";
                }
            }
        }
        else
        {
            Entry.BorderBrush = Brushes.Red;
            resultLabel.Content = "Campo invalido";
        }
    }
}