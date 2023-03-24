namespace BlazorBlog.Services
{
    public class PrepareDataService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public PrepareDataService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
            //if(_dbContext.Authors.Count() == 0)
            //{
            //    _dbContext.Authors.Add(new Data.Author
            //    {
            //        JoinAt = DateTime.Now,
            //        Email = 
            //    });
            //}
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
