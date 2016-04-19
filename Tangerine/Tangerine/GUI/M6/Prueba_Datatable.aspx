<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Prueba_Datatable.aspx.cs" Inherits="Tangerine.GUI.M6.Prueba_Datatable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div class="box-body table-responsive">
    <table id="example" class="table table-bordered table-striped dataTable">
       <thead>
              <tr>
                    
                   <th>Nombre</th>
                   <th>Tipo</th>
                   <th>Marca</th>
                   <th>Color</th>
                   <th>Estatus</th>
                   <th>Precio</th>
                   <th>Stock Min</th>
                   <th>Total</th>
                   <th>Dojo</th>
              </tr>
        </thead>
     <tbody>

       
         <tr>
             <td> 1 </td>
             <td> 2 </td>
             <td> 3 </td>
             <td> 4 </td>
             <td> 5 </td>
             <td> 6 </td>
             <td> 7 </td>
             <td> 8 </td>
             <td> 9 </td>
         </tr>

          <tr>
             <td> a </td>
             <td> b </td>
             <td> c </td>
             <td> d </td>
             <td> e </td>
             <td> f </td>
             <td> g </td>
             <td> h </td>
             <td> i </td>
         </tr>
                                                  
      </tbody>

        </table>
    </div>


     <script type="text/javascript">
         $(document).ready(function () {

             var table = $('#example').DataTable({
                 "language": {
                     "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                 }
             });
             var req;
             var tr;

             $('#example tbody').on('click', 'a', function () {
                 if ($(this).parent().hasClass('selected')) {
                     req = $(this).parent().prev().prev().prev().prev().text();
                     tr = $(this).parents('tr');//se guarda la fila seleccionada
                     $(this).parent().removeClass('selected');

                 }
                 else {
                     req = $(this).parent().prev().prev().prev().prev().text();
                     tr = $(this).parents('tr');//se guarda la fila seleccionada
                     table.$('tr.selected').removeClass('selected');
                     $(this).parent().addClass('selected');
                 }
             });



             $('#modal-delete').on('show.bs.modal', function (event) {
                 var modal = $(this)
                 modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                 modal.find('#req').text(req)
             })
             $('#btn-eliminar').on('click', function () {
                 table.row(tr).remove().draw();//se elimina la fila de la tabla
                 $('#modal-delete').modal('hide');//se esconde el modal
             });


         });

         </script>


</asp:Content>