(function () {
    GetAllEmployee();
}())

function CallEventListener() {
    addCloseButtonListener();
    addInsertButtonListener();
    submitInsertFormListener();
}

function GetAllEmployee() {
    const request = new XMLHttpRequest();
    request.open("GET", "http://localhost:5089/api/roomservice");
    request.send();
    request.onload = function () {
        //console.log(JSON.parse(request.responseText));
        let employees = JSON.parse(request.responseText);
        console.log(employees)
        AllEmployee(employees);
        CallEventListener();
    }
}

function AllEmployee(employees) {
    let div = document.querySelector('.grid-container table tbody');
    div.innerHTML = '';
    for (let employee of employees) {
        let row = document.createElement('tr');
        row.innerHTML = `
                        <td>
                            <a href="/Roster/${employee.employeeNumber}" class="blue-button button edit-button">Edit</a>
                            <a data-number="${employee.employeeNumber}" class="blue-button button roster-button">Roster</a>
                        </td>
                        <td>${employee.employeeNumber}</td>
                        <td>${employee.fullName}</td>
                        <td>${employee.outsourcingCompany}</td>
                `;

        div.appendChild(row);

    }
}


function addCloseButtonListener() {
    // Ambil elemen tombol close
    var closeButton = document.querySelector('.close-button');

    // Ambil elemen modal-layer, popup-dialog, dan elemen-elemen lainnya
    var modalLayer = document.querySelector('.modal-layer');
    var popupDialog = document.querySelector('.popup-dialog');
    var inputElements = document.querySelectorAll('.popup-dialog input');
    var validationMessageElements = document.querySelectorAll('.popup-dialog .validation-message');

    // Tambahkan event listener untuk klik pada tombol close
    closeButton.addEventListener('click', function (event) {
        event.preventDefault();
        // Hapus kelas yang menandakan bahwa modal dibuka
        modalLayer.classList.remove('modal-layer--opened');
        popupDialog.classList.remove('popup-dialog--opened');

        // Mengosongkan nilai input dan textarea
        inputElements.forEach(function (input) {
            input.value = '';
        });

        // Mengosongkan teks pesan validasi
        validationMessageElements.forEach(function (validationMessage) {
            validationMessage.textContent = '';
        });



    });
}

function addInsertButtonListener() {
    // Ambil elemen tombol "Insert New Employee"
    var insertButton = document.querySelector('.insert-button');

    // Ambil elemen modal-layer dan popup-dialog
    var modalLayer = document.querySelector('.modal-layer');
    var popupDialog = document.querySelector('.popup-dialog');

    // Tambahkan event listener untuk klik pada tombol "Insert New Employee"
    insertButton.addEventListener('click', function (event) {
        // Tampilkan modal dengan menambahkan kelas yang menandakan bahwa modal dibuka
        modalLayer.classList.add('modal-layer--opened');
        popupDialog.classList.add('popup-dialog--opened');
    });
}


function submitInsertFormListener() {
    // Ambil elemen tombol pada formulir
    var insertForm = document.querySelector('.form-dialog .insertEmployee');

    // Tambahkan event listener untuk klik pada tombol formulir
    insertForm.addEventListener('submit', function (event) {
        event.preventDefault();
        // DOM untuk Kumpulkan data dari formulir
        let employeeNumber = document.querySelector('.form-dialog .employeeNumber').value;
        let firstName = document.querySelector('.form-dialog .firstName').value;
        let middleName = document.querySelector('.form-dialog .middleName').value;
        let lastName = document.querySelector('.form-dialog .lastName').value;
        let company = document.querySelector('.form-dialog .outSourcingCompany').value;

        // DOM untuk error
        let errorNumber = document.querySelector('.form-dialog .error-employeeNumber');
        let errorfirstName = document.querySelector('.form-dialog .error-firstName');
        let errorlastName = document.querySelector('.form-dialog .error-lastName');
        let errorcompany = document.querySelector('.form-dialog .error-outSourcingCompany');

        data = {
            employeeNumber: employeeNumber,
            firstName: firstName,
            middleName: middleName,
            lastName: lastName,
            outSourcingCompany: company
        }

        console.log(data);

        // Konfigurasi permintaan
        var requestMethod = 'POST';
        var subUrl = 'http://localhost:5089/api/roomservice/InsertEmployee';
        var contentType = 'application/json';

        // Buat objek XMLHttpRequest
        var request = new XMLHttpRequest();
        request.open(requestMethod, subUrl);
        request.setRequestHeader('Content-Type', contentType);
        request.send(JSON.stringify(data));
        
        // Ketika permintaan selesai
        request.onload = function () {
            let result = JSON.parse(request.response);
            console.log(result);
            if (result.errors) {
                if (result.errors.EmployeeNumber) {
                    errorNumber.innerHTML = result.errors.EmployeeNumber;
                } else {
                    errorNumber.innerHTML = '';
                }
                if (result.errors.FirstName) {
                    errorfirstName.innerHTML = result.errors.FirstName;
                } else {
                    errorfirstName.innerHTML = '';
                }
                if (result.errors.LastName) {
                    errorlastName.innerHTML = result.errors.LastName;
                } else {
                    errorlastName.innerHTML = '';
                }
                if (result.errors.OutsourcingCompany) {
                    errorcompany.innerHTML = result.errors.OutsourcingCompany;
                } else {
                    errorcompany.innerHTML = '';
                }
            } else {
                console.log("Data berhasil ditambahkan");
                insertForm.reset();
                location.reload();
            }
        };

        

    });
}




