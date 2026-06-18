$(document).ready(function () {
    const $form = $('#employeeForm');

    $form.on('submit', function (event) {
        event.preventDefault();

        console.log('AJAX submit intercepted');

        clearServerErrors();

        if (!$form.valid()) {
            return;
        }

        $.ajax({
            url: $form.attr('action'),
            method: 'POST',
            data: $form.serialize(),
            headers: {
                'X-Requested-With': 'XMLHttpRequest'
            },
            success: function (response) {
                console.log('AJAX success', response);
                
                addEmployeeRow(response.employee);
                $('#emptyEmployeesMessage').hide();
                $form[0].reset();
            },
            error: function (xhr) {
                if (xhr.responseJSON && xhr.responseJSON.errors) {
                    showServerErrors(xhr.responseJSON.errors);
                    return;
                }

                alert('No fue posible guardar el empleado.');
            }
        });
    });

    function addEmployeeRow(employee) {
        const row = `
            <tr>
                <td>${escapeHtml(employee.fullName)}</td>
                <td>${escapeHtml(employee.email)}</td>
                <td>${escapeHtml(employee.departmentName)}</td>
                <td>${employee.monthlySalary}</td>
                <td>${employee.annualBonus}</td>
            </tr>
        `;

        $('#employeesTableBody').append(row);
    }

    function showServerErrors(errors) {
        Object.keys(errors).forEach(function (key) {
            const messages = errors[key];

            const fieldName = key.replace('Form.', '');
            const $field = $('[name="' + fieldName + '"]');

            if ($field.length === 0) {
                return;
            }

            const $validationSpan = $('[data-valmsg-for="Form.' + fieldName + '"]');

            if ($validationSpan.length > 0) {
                $validationSpan
                    .removeClass('field-validation-valid')
                    .addClass('field-validation-error')
                    .text(messages.join(' '));
            }
        });
    }

    function clearServerErrors() {
        $('.field-validation-error')
            .removeClass('field-validation-error')
            .addClass('field-validation-valid')
            .text('');
    }

    function escapeHtml(value) {
        return $('<div />').text(value ?? '').html();
    }
});