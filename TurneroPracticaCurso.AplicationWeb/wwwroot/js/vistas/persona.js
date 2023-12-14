$(document).ready(function () {
    $(document).on('show.bs.modal', '#modalData', async function (e) {
        try {
            console.log("Modal is shown");
            const data = await $.ajax({
                url: '/Persona/ListarRol',
                method: 'GET'
            });

            // Verifica si data es undefined o null
            if (data) {
                $('#rolSelect').empty().append('<option selected>Seleccione un rol</option>');
                $.each(data, function (index, item) {
                    console.log(data)
                    $('#rolSelect').append('<option value="' + item.idRol + '">' + item.descripcion + '</option>');
                });
            } else {
                console.error('La respuesta del servidor es undefined o null.');
            }
        } catch (error) {
            console.error(error);
        }
    });
});