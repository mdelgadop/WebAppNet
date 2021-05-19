using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Services.Interfaces;
using Application.Factories.Services;
using Application.Dtos;
using Application.Messages;

namespace WebAppCB.Test
{
    [TestClass]
    public class DEAServiceTest
    {
        [TestMethod]
        public void TestGetDEAByRequest()
        {
            IDEAService service = DEAServiceFactory.CreateMock();

            DEAListResponse response = service.GetDEAByRequest(new DEAListRequest());

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.DEAList != null);
            Assert.IsTrue(response.DEAList.Count == 5);
        }

        [TestMethod]
        public void TestGetDEAElement()
        {
            IDEAService service = DEAServiceFactory.CreateMock();

            string codigo = "2021-75";
            DEAResponse response = service.GetDEAElement(new DEARequest() { Codigo = codigo });

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.DEAElement != null);
            Assert.AreEqual(response.DEAElement.Codigo, codigo);
        }

        [TestMethod]
        public void TestCreateDEA()
        {
            IDEAService service = DEAServiceFactory.CreateMock();

            CreateDEAResponse response = service.CreateDEA(new CreateDEARequest() { NewDEA = CreateDEAMock() });

            Assert.IsTrue(response.Success);

            DEAListResponse response2 = service.GetDEAByRequest(new DEAListRequest());

            Assert.IsTrue(response2.Success);
            Assert.IsTrue(response2.DEAList != null);
            Assert.IsTrue(response2.DEAList.Count == 6);
        }

        [TestMethod]
        public void TestNearestLessThan1Km()
        {
            IDEAService service = DEAServiceFactory.CreateMock();

            ClosestDEAResponse response = service.GetClosestDEA(new ClosestDEARequest() { CoordenadaY = 4473020, CoordenadaX = 440640 });

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.DEAElement.Codigo, "2021-48");
            Assert.IsTrue(response.LessThan1Km);
        }

        [TestMethod]
        public void TestNearestMoreThan1Km()
        {
            IDEAService service = DEAServiceFactory.CreateMock();

            ClosestDEAResponse response = service.GetClosestDEA(new ClosestDEARequest() { CoordenadaY = 4055900, CoordenadaX = 401880 });

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.DEAElement.Codigo, "2021-62");
            Assert.IsFalse(response.LessThan1Km);
        }

        private DEADto CreateDEAMock()
        {
            DEADto dto = new DEADto()
            {
                Codigo = "2019-177",
                HorarioAcceso = "7-20 H",
                TipoEstablecimiento = Infrastructure.Enums.TipoEstablecimientoEnum.Otros,
                TipoTitularidad = Infrastructure.Enums.TipoTitularidadEnum.Privada,
                Municipio = new MunicipioDto()
                {
                    Pais = "ES",
                    Codigo = "079",
                    Nombre = "Madrid"
                },
                Direccion = new DireccionDto()
                {
                    Puerta = string.Empty,
                    TipoVia = Infrastructure.Enums.TipoViaEnum.CALLE,
                    Piso = "2",
                    Ubicacion = "PLANTA 2 - COMMODITY CORNER",
                    NombreVia = "de Emilio Vargas",
                    PortalNumero = "4",
                    CodigoPostal = "28043",
                    CoordenadaY = 4477619,
                    CoordenadaX = 444434
                }
            };

            return dto;
        }

    }
}
