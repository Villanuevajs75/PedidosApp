using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = RegistroPedidos.Instancia.Pedidos;

            // Asignar columnas 
            dgvPedidos.AutoGenerateColumns = true;

            // Prevenir que la columna "MetodoEntrega"
            dgvPedidos.DataSource = RegistroPedidos.Instancia.Pedidos;

            // Ocultar la columna "MetodoEntrega" al iniciar, incluso si está vacía
            if (dgvPedidos.Columns["MetodoEntrega"] != null)
                dgvPedidos.Columns["MetodoEntrega"].Visible = false;

            // Renombrar "TipoMetodoEntrega"
            if (dgvPedidos.Columns["TipoMetodoEntrega"] != null)
                dgvPedidos.Columns["TipoMetodoEntrega"].HeaderText = "Tipo de Entrega";

            // Cargar ComboBox con tipos de entrega
            cmbFiltroEntrega.Items.Add("Todos");
            cmbFiltroEntrega.Items.Add("Camión");
            cmbFiltroEntrega.Items.Add("Dron");
            cmbFiltroEntrega.Items.Add("Motocicleta");
            cmbFiltroEntrega.Items.Add("Bicicleta");
            cmbFiltroEntrega.SelectedIndex = 0; // Por defecto: Todos

            // DataGridView y ocultar columna no deseada
            dgvPedidos.AutoGenerateColumns = true;
            dgvPedidos.DataSource = RegistroPedidos.Instancia.Pedidos;

            if (dgvPedidos.Columns["MetodoEntrega"] != null)
                dgvPedidos.Columns["MetodoEntrega"].Visible = false;

        }

 

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIONES
                if (string.IsNullOrWhiteSpace(txtCliente.Text))
                {
                    MessageBox.Show("Por favor ingresa el nombre del cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProducto.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nudPeso.Value <= 0)
                {
                    MessageBox.Show("El peso debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nudDistancia.Value <= 0)
                {
                    MessageBox.Show("La distancia debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  CAPTURAR DATOS DEL FORMULARIO
                string cliente = txtCliente.Text;
                string producto = cmbProducto.SelectedItem.ToString();
                bool urgente = chkUrgente.Checked;
                double peso = Convert.ToDouble(nudPeso.Value);
                int distancia = Convert.ToInt32(nudDistancia.Value);

                //  CREAR EL PEDIDO Y AGREGARLO AL REGISTRO
                Pedido pedido = new Pedido(cliente, producto, urgente, peso, distancia);
                RegistroPedidos.Instancia.AgregarPedido(pedido);

                //  MOSTRAR RESULTADO EN UNA VENTANA EMERGENTE
                MessageBox.Show(
                    $"Cliente: {cliente}\n" +
                    $"Entrega: {pedido.MetodoEntrega.TipoEntrega()}\n" +
                    $"Costo: ${pedido.ObtenerCosto():0.00}",
                    "Resultado del Pedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

              
                //  ACTUALIZAR EL DATAGRIDVIEW CON TODOS LOS PEDIDOS
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = RegistroPedidos.Instancia.Pedidos;

                // ✅ OCULTAR LA COLUMNA 'MetodoEntrega' (para evitar duplicados/confusión)
                if (dgvPedidos.Columns["MetodoEntrega"] != null)
                    dgvPedidos.Columns["MetodoEntrega"].Visible = false;


                //  RENOMBRAR LA COLUMNA 'TipoMetodoEntrega' A UN NOMBRE MÁS AMIGABLE
                if (dgvPedidos.Columns["TipoMetodoEntrega"] != null)
                    dgvPedidos.Columns["TipoMetodoEntrega"].HeaderText = "Tipo de Entrega";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbFiltroEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroEntrega.SelectedItem == null)
                return; // Evita el error si aún no hay selección

            string filtro = cmbFiltroEntrega.SelectedItem.ToString();

            if (filtro == "Todos")
            {
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = RegistroPedidos.Instancia.Pedidos;
            }
            else
            {
                var pedidosFiltrados = RegistroPedidos.Instancia.Pedidos
                    .Where(p => p.MetodoEntrega.TipoEntrega() == filtro)
                    .ToList();

                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = pedidosFiltrados;
            }

            if (dgvPedidos.Columns["MetodoEntrega"] != null)
                dgvPedidos.Columns["MetodoEntrega"].Visible = false;
        }
    }
}
