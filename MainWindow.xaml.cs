using AsyncStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncStoreApp;


public partial class MainWindow : Window
{
    private readonly DataContext _dataContext;
    private readonly ProductRepository _productRepository;
    public MainWindow()
    {
        InitializeComponent();

        var config = new ConfigurationBuilder()
           .AddJsonFile("config.json")
           .Build();

        DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
           .UseSqlServer(config.GetConnectionString("Default"))
           .Options;
        _dataContext = new DataContext(options);

        _productRepository = new ProductRepository(_dataContext);

        LoadData();
    }
    private async void LoadData()
    {
        var products = await _productRepository.GetAllAsync(CancellationToken.None);
        dataGridProducts.ItemsSource = products;
    }
    private async void AddProduct_Click(object sender, RoutedEventArgs e)
    {
        string productName = tx_ProductName.Text;
        string priceText = tx_Price.Text;
        string description = tx_Description.Text;


        if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }
        double price;
        if (!double.TryParse(priceText, out price))
        {
            MessageBox.Show("Invalid price format. Please enter a valid number.");
            return;
        }

        var product = new Product
        {
            ProductName = productName,
            ProductInfo = new ProductInfo
            {
                Description = description,
                Price = price
            }
        };

        try
        {
            await _productRepository.AddAsync(product);
            LoadData();
            tx_ProductName.Clear();
            tx_Price.Clear();
            tx_Description.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
