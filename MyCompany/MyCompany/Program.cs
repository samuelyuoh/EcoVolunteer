using Microsoft.AspNetCore.Identity;
using MyCompany;
using MyCompany.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<AchievementService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<OrganiserService>();
builder.Services.AddScoped<UserService>();

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

//testing jordan branch
//ryan test