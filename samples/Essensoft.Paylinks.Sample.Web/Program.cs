using Essensoft.Paylinks.Alipay.Client.Extensions;
using Essensoft.Paylinks.Sample.Web;
using Essensoft.Paylinks.Sample.Web.Services;
using Essensoft.Paylinks.WeChatPay.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PaylinksOptions>(builder.Configuration.GetSection("Paylinks"));

builder.Services.AddAlipayClient();

builder.Services.AddWeChatPayClient();

builder.Services.AddHostedService<WeChatPayBackgroundService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
