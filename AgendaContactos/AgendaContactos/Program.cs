var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Agregamos el run time compilation del paquete nuget que instalamos
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();