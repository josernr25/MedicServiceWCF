using MedicServiceWCF.DataAccess;
using MedicServiceWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MedicServiceWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public MedicamentoModel GetMedicamento(int id)
        {
            try
            {
                using (var db = new MedicoDBEntities())
                {
                    Medicamento response = db.Medicamento.Where(x => x.IIDMEDICAMENTO == id).FirstOrDefault();

                    return new MedicamentoModel
                    {
                        IdMedicamento = response.IIDMEDICAMENTO,
                        Nombre = response.NOMBRE,
                        Concentracion = response.CONCENTRACION,
                        IdFormaFarmaceutica = response.IIDFORMAFARMACEUTICA,
                        Precio = response.PRECIO,
                        Stock = response.STOCK,
                        Presentacion = response.PRESENTACION,
                        BHabilitado = response.BHABILITADO
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public IEnumerable<MedicamentoModel> GetMedicamentos()
        {
            try
            {
                using (var db = new MedicoDBEntities())
                {
                    return from m in db.Medicamento
                           join f in db.FormaFarmaceutica
                           on m.IIDFORMAFARMACEUTICA equals f.IIDFORMAFARMACEUTICA
                           select new MedicamentoModel
                           {
                               IdMedicamento = m.IIDMEDICAMENTO,
                               Nombre = m.NOMBRE,
                               Concentracion = m.CONCENTRACION,
                               NombreFormaFarmaceutica = f.NOMBRE,
                               Precio = m.PRECIO,
                               Stock = m.STOCK,
                               Presentacion = m.PRESENTACION,
                               BHabilitado = m.BHABILITADO
                           };
                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public bool AddMedicamento(MedicamentoModel medicamento)
        {
            try
            {
                using (var db = new MedicoDBEntities())
                {
                    db.Medicamento.Add(new Medicamento 
                                        { 
                                            IIDMEDICAMENTO = medicamento.IdMedicamento,
                                            NOMBRE = medicamento.Nombre,
                                            CONCENTRACION = medicamento.Concentracion,
                                            IIDFORMAFARMACEUTICA = medicamento.IdFormaFarmaceutica,
                                            PRECIO = medicamento.Precio,
                                            STOCK = medicamento.Stock,
                                            PRESENTACION = medicamento.Presentacion,
                                            BHABILITADO = medicamento.BHabilitado
                                        });
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool UpdateMedicamento(MedicamentoModel medicamento)
        {
            try
            {
                using (var db = new MedicoDBEntities())
                {
                    Medicamento response = db.Medicamento.Where(x => x.IIDMEDICAMENTO == medicamento.IdMedicamento).FirstOrDefault();

                    response.IIDMEDICAMENTO = medicamento.IdMedicamento;
                    response.NOMBRE = medicamento.Nombre;
                    response.CONCENTRACION = medicamento.Concentracion;
                    response.IIDFORMAFARMACEUTICA = medicamento.IdFormaFarmaceutica;
                    response.PRECIO = medicamento.Precio;
                    response.STOCK = medicamento.Stock;
                    response.PRESENTACION = medicamento.Presentacion;
                    response.BHABILITADO = medicamento.BHabilitado;

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool DeleteMedicamento(int id)
        {
            try
            {
                using (var db = new MedicoDBEntities())
                {
                    var medicamento = db.Medicamento.Where(x => x.IIDMEDICAMENTO == id).FirstOrDefault();

                    db.Medicamento.Remove(medicamento);

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<FormaFarmaceuticaModel> GetFormaFarmaceuticas()
        {
            try
            {
                using (var db = new MedicoDBEntities())
                {
                    return db.FormaFarmaceutica.Select( x => new FormaFarmaceuticaModel 
                                                        {
                                                            IdFormaFarmaceutica = x.IIDFORMAFARMACEUTICA,
                                                            Nombre = x.NOMBRE,
                                                            BHabilitado = x.BHABILITADO
                                                        });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
