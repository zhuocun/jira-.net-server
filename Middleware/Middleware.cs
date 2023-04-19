public static class Middleware
{
    public static void Configure(IApplicationBuilder app, bool isDevelopment)
    {
        if (isDevelopment)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
