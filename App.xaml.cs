using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROG_2B_POE_Part_2.Data;
using System.Configuration;
using System.Data;
using System.Windows;


namespace PROG_2B_POE_Part_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Retrieve the connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Add DbContext to the service collection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add other services or ViewModels if needed
            //services.AddTransient<MainWindow>(provider => new MainWindow(provider.GetService<AppDbContext>()));
            services.AddTransient<MainWindow>();
            services.AddTransient<ManagerViewWindow>();
            services.AddTransient<LecturerViewWindow>();
            services.AddTransient<LecturerCreateWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();  // Initialize MainWindow with DI
            //var managerWindow = _serviceProvider.GetService<ManagerViewWindow>();
            //var lectureviewWindow = _serviceProvider.GetService<LecturerViewWindow>();
            //var lecturecreateWindow = _serviceProvider.GetService<LecturerCreateWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}