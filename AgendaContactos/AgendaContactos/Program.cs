/*El enrutamiento de razor funciona asi, si queremos acceder a una
pagina directa en concreto, como /contacto, lo que va a ser es
que va a ir a la carpeta Pages y va a buscar el archivo contacto.cshtml,
si queremos acceder a /menu/bebidas debera entrar a la carpeta menu
en Pages y el archivo bebidas.cshtml*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Agregamos el run time compilation del paquete nuget que instalamos
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
} else {
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();