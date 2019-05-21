using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using System.ServiceModel;
using SistemaHorasConsulta.WSSeguridadTec;
using SistemaHorasConsulta.wsSeguridad;
using Microsoft.Ajax.Utilities;

namespace SistemaHorasConsulta.Controllers
{
    public class HomeController : Controller
    {
    
        [AllowAnonymous]
        public ActionResult Autenticacion()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    
        private bool EsEstudianteActivo(string IdUsuario)
        {
            wsDar.AdmisionyRegistro wsdar = new wsDar.AdmisionyRegistro();
            DataSet ds = wsdar.DATOS_ESTUDIANTE(IdUsuario);
            return ds.Tables[0].Rows.Count > 0;
        }
        public ActionResult Ingresar(List<String> Datos, string returnUrl)
        {
            string _Usuario = Datos[0];
            string _Contraseña = Datos[1];

            Seguridad wsseg = new Seguridad();
            WSSeguridadTec.TEC_IWCF_SeguridadClient wssegTec = new TEC_IWCF_SeguridadClient();
            TEC_Credenciales credenciales = new TEC_Credenciales();
            credenciales.CodigoAplicacionLogueado = 1;
            credenciales.ContrasenaUsuarioAplicacionLogueado = "";
            credenciales.UsuarioAplicacionLogueado = "";
            credenciales.IpAddress = "1.0.0.0";


            var respuestaAutenticacion = wssegTec.Usu_AutenticarUsuario(_Usuario, _Contraseña, credenciales);

            var Foto = new wsFotosEstudiantes.wsUtilitarios();
            //int codTipoUsuario = Convert.ToInt32(Datos[2]);
            //int codTipoUsuario = codTipoUsuario_funtion(_Usuario, _Contraseña);
            Session["COD_SEDE"] = "SJ"; //funciona solo para Cartago ahorita
            int codTipoUsuario = Convert.ToInt32(Datos[2]); //funciona solo para funcionarios ahorita
            try
            {
                if ((_Usuario != "") && (_Contraseña != ""))
                {
                    switch (codTipoUsuario)
                    {
                        case 1://Funcionario
                            {
                                if (wsseg.ValidarFuncionario(_Usuario, _Contraseña))
                                {
                                    //wsseg.ValidarFuncionario(_Usuario, _Contraseña);
                                    Session.Add("ID_USUARIO", _Usuario);
                                    Session.Add("COD_USUARIO", "FUNCIONARIO");
                                    Session.Add("NOM_USUARIO", wsseg.ObtenerNombreUsuario(_Usuario)); //obtener nombre completo del usuario.
                                    Session.Add("COD_SEDE", Session["COD_SEDE"].ToString());
                                    Session.Add("NOM_DEPARTAMENTO", wsseg.ObtenerDepartamento(_Usuario));
                                    User.Identity.Name.Equals(_Usuario);

                                    int idEstudiante;
                                    if (int.TryParse(_Usuario, out idEstudiante))
                                    {
                                        var obtieneFoto = Foto.CargarFoto("200");
                                        var foto = Convert.ToBase64String(Foto.CargarFoto("200"));
                                        Session["FOTO"] = foto;
                                    }
                                    else
                                    {
                                        var obtieneFoto = Foto.CargarFoto("200");
                                        Session["FOTO"] = null;
                                    }

                                    Seguridad wsSeg = new Seguridad();
                                    string _Cedula = "", _Correo = "";
                                    _Cedula = wsSeg.ObtenerCedula(_Usuario);
                                    _Correo = _Usuario + "@itcr.ac.cr";
                                    Session["Email"] = _Correo;
                                    Session["NUM_CEDULA"] = _Cedula;
                                    var res = new { Success = "True" };
                                    return Json(res, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    var res = new { Success = "False" };
                                    return Json(res, JsonRequestBehavior.AllowGet);
                                }
                            }
                        case 2:
                            {
                                //Valida que el estudiante exista
                                if (!wsseg.ValidarEstudianteBit(_Usuario, _Contraseña, MvcApplication.CodAplicación, Session["COD_SEDE"].ToString()))
                                {
                                    //throw new ITCRException("El Pin es incorrecto.");
                                    var res = new { Success = "False" };
                                    return Json(res, JsonRequestBehavior.AllowGet);

                                }
                                //validar que sea estudiante activo
                                if (!EsEstudianteActivo(_Usuario))
                                {
                                    var res = new { Success = "False" };
                                    return Json(res, JsonRequestBehavior.AllowGet);
                                }
                                int idEstudiante;
                                if (int.TryParse(_Usuario, out idEstudiante))
                                {
                                    //var obtieneFoto = Foto.CargarFoto(_Usuario);
                                    if (Foto.CargarFoto(_Usuario) != null)
                                    {
                                        var foto = Convert.ToBase64String(Foto.CargarFoto(_Usuario));
                                        Session["FOTO"] = foto;
                                    }
                                    else {
                                        Session["Foto"] = null ;
                                    }
                                }
                                else
                                {
                                    Session["FOTO"] = null;
                                }

                                Session["Tipo_Usuario"] = 2;

                                if (true)
                                {
                                    Session.Add("ID_USUARIO", "USR_Timpresion");
                                    Session.Add("CARNE", _Usuario);
                                    Session.Add("COD_USUARIO", "ESTUDIANTE");
                                    Session.Add("NUM_CEDULA", wsseg.ObtenerCedula(_Usuario)); //obtener número de cédula si tiene.
                                    Session.Add("NOM_USUARIO", wsseg.ObtenerNombreUsuario(_Usuario)); //obtener nombre completo del usuario.
                                    Session.Add("COD_SEDE", Session["COD_SEDE"].ToString());
                                    var res = new { Success = "True" };
                                    return Json(res, JsonRequestBehavior.AllowGet);
                                }
                            }
                            break;
                        case 3:

                            Session["Tipo_Usuario"] = 3;

                            if (true)
                            {
                                wsseg.ValidarUsuarioSistema(_Usuario, _Contraseña, MvcApplication.CodAplicación, Session["COD_SEDE"].ToString());
                                Session.Add("ID_USUARIO", _Usuario);
                                Session.Add("NUM_CEDULA", wsseg.ObtenerCedula(_Usuario)); //obtener número de cédula si tiene.
                                Session.Add("NOM_USUARIO", wsseg.ObtenerNombreUsuario(_Usuario)); //obtener nombre completo del usuario.
                                Session.Add("COD_SEDE", Session["COD_SEDE"].ToString());
                                Session["FOTO"] = null;
                                var res = new { Success = "True" };
                                return Json(res, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                var res = new { Success = "False" };
                                return Json(res, JsonRequestBehavior.AllowGet);
                            }
                    }
                }
            }
            catch (FaultException ex)
            {
                string error = ex.Message.ToString();
                Response.Write("<script>alert('" + error + "');</script>");
                return View("");
            }
            var result = new { Success = "False" };
            //return null;
            return Content("Datos incorrectos");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
           
                return RedirectToAction("SeleccionarTematica", "Estudiante");
            
        }

        /// <summary>
        /// Finaliza la sesión del usuario
        /// </summary>

        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Autenticacion", "Home");
        }

    }
}