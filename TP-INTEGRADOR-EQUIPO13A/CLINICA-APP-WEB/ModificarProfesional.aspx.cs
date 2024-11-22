using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class ModificarProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProfesionalNegocio negocio = new ProfesionalNegocio();

            if (!IsPostBack)
            {

                int id = 0;
                if (int.TryParse(Request.QueryString["id"], out id) && id > 0)
                {
                    List<Profesional> lista = negocio.listar_porID(id);
                    Profesional seleccionado = lista[0];
                    if (lista.Count > 0)
                    {
                        
                       
                        txtDni.Text = seleccionado.Persona.Dni.ToString();
                        txtNombre.Text = seleccionado.Persona.Nombre;
                        txtApellido.Text = seleccionado.Persona.Apellido;
                        txtFechaNac.Text = seleccionado.Persona.FechaNacimiento.ToString("dd/MM/yyyy");
                        txtEmail.Text = seleccionado.Persona.ContactoCliente.Email;
                        txtTelefono.Text = seleccionado.Persona.ContactoCliente.telefono.ToString();
                        txtDireccion.Text = seleccionado.Persona.ContactoCliente.Direccion;
                        txtUsuario.Text = seleccionado.Usuario.User;
                        TxtPass.Text = seleccionado.Usuario.Password;
                        TxtFechaIng.Text = seleccionado.FechaIngreso.ToString("dd/MM/yyyy");
                        TxtMatricula.Text = seleccionado.Matricula.ToString();
                        lblEspecialidades.Text = string.Join(", ", seleccionado.Especialidades.Select(especialidad => especialidad.NombreEspecialidad));



                    }
                    else
                    {
                        lblMensaje.Text = "No se encontró el profesional con el ID proporcionado.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Visible = true;
                    }
                }
                else
                {
                    lblMensaje.Text = "ID de profesional no válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                }
                
            }
            
        }

        
        protected void btnModificarProfesional_Click(object sender, EventArgs e)
        {
            Profesional seleccionado = new Profesional();
            ProfesionalNegocio negocio = new ProfesionalNegocio();
            seleccionado.IdProfesional = int.Parse(Request.QueryString["id"]);
            seleccionado.Persona.Nombre = txtNombre.Text;
            seleccionado.Persona.Apellido = txtApellido.Text;
            seleccionado.Persona.Dni = txtDni.Text;
            seleccionado.Persona.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
            seleccionado.Persona.ContactoCliente.Direccion = txtDireccion.Text;
            seleccionado.Persona.ContactoCliente.telefono = txtTelefono.Text;
            seleccionado.Persona.ContactoCliente.Email = txtEmail.Text;
            seleccionado.Usuario.User = txtUsuario.Text;
            seleccionado.Usuario.Password = TxtPass.Text;
            seleccionado.FechaIngreso = DateTime.Parse(TxtFechaIng.Text);
            seleccionado.Matricula = TxtMatricula.Text;
            negocio.ModificarProfesional(seleccionado);
            Response.Redirect("BuscarProfesional.aspx", false);
        }

        protected void btnEspecialidades_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Especialidades")
            {
                int idProfesional = int.Parse(Request.QueryString["id"]);
                Response.Redirect("ModificarEspecialidades.aspx?id=" + idProfesional);

            }
        }
    }
}
