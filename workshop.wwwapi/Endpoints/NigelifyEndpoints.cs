namespace workshop.wwwapi.Endpoints
{
    public static class NigelifyEndpoints
    {
        public static void ConfigureNigelify(this WebApplication app)
        {

            app.MapGet("nigelify/{name}", (string name) => { return name.Nigelify(); });

        }
    }
}
