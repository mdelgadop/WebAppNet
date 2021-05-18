namespace Application.Messages
{
    public class DEAListRequest
    {
        //Listado de DEA's. Debe permitir ordenar por municipio y código postal. Debe permitir filtrar por municipio, código postal y si es o no de citibox.
        
        public bool OrderByMunicipio { get; set; }

        public bool OrderByCodigoPostal { get; set; }

        public string FilterMunicipioCode { get; set; }

        public string FilterMunicipioNombre { get; set; }

        public bool IsPublico { get; set; }

        public bool IsPrivado { get; set; }

        public bool HasAnyFilter()
        {
            return !string.IsNullOrEmpty(FilterMunicipioNombre) || !string.IsNullOrEmpty(FilterMunicipioCode) || IsPublico || IsPrivado;
        }

    }
}
