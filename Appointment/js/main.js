var customers = [];

window.onload = function () {
    if (sessionStorage.getItem("customers") != null) {
        customers = JSON.parse(sessionStorage.getItem("customers"));
        for (let i = 0; i < customers.length; i++) {
            const customer = customers[i];
            mapToTable(customer);
        }
    }
}

function addCustomer() {
    const firstName = document.getElementById("txtFirstName");
    const lastName = document.getElementById("txtLastName");
    const age = document.getElementById("txtAge");
    const customer = createCustomer(firstName.value, lastName.value, age.value);

    customers.push(customer);
    sessionStorage.setItem("customers", JSON.stringify(customers))
    mapToTable(customer);
    clearForm();
    firstName.focus();
}

function mapToTable(customer) {
    const table = document.getElementById("tblCustomers");
    const row = document.createElement("tr");
    
    const c1 = document.createElement("td");
    c1.innerText = customer.firstName;
    const c2 = document.createElement("td");
    c2.innerText = customer.lastName;
    const c3 = document.createElement("td");
    c3.innerText = customer.age;
    const c4 = document.createElement("td");
    const btn = document.createElement("button");
    btn.classList.add("btn");
    btn.classList.add("table-button");
    btn.classList.add("alert-button");
    btn.innerText = "Sil";
    btn.onclick = () => removeCustomer(customer.firstName, customer.lastName, customer.age);
    c4.appendChild(btn);

    row.appendChild(c1);
    row.appendChild(c2);
    row.appendChild(c3);
    row.appendChild(c4);

    table.appendChild(row);
}

function clearForm() {
    document.getElementById("txtFirstName").value = "";
    document.getElementById("txtLastName").value = "";
    document.getElementById("txtAge").value = "";
}

function createCustomer(firstName, lastName, age) {
    return {
        firstName,
        lastName,
        age
    };
}


function removeCustomer(firstName, lastName, age) {
    const firstLength = customers.length;
    customers = customers.filter(c => c.firstName != firstName &&
                                      c.lastName != lastName &&
                                      c.age != age);
    const lastLength = customers.length;

    if (firstLength != lastLength) {
        //Eski satırları sil
        const table = document.getElementById("tblCustomers");

        for (let i = table.rows.length - 1; i > 0; i--) {
            table.deleteRow(i);
        }
        //yeni değerleri ekle
        for (let i = 0; i < customers.length; i++) {
            const customer = customers[i];
            mapToTable(customer);
        }
        // session2ı baştan yenile
        sessionStorage.setItem("customers", JSON.stringify(customers))
    }
}