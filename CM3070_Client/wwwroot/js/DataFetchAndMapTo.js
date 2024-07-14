
function createHeaders(headerText, id, cls) {
    const headerElement = document.createElement("th");
    headerElement.textContent = headerText;
    for (let i = 0; i < cls.length; i++) {
        headerElement.classList.add(cls[i]);
    }
    headerElement.setAttribute('id', id)
    headerElement.setAttribute('scope', 'col')

    return headerElement;
}

/*  
Create button in cell with function to load popup
*/
function createButtonCell(cellData, id, popId) {
    const cellElement = document.createElement("td");

    cellElement.setAttribute("align", "center");
    const buttonElement = document.createElement("button");

    buttonElement.setAttribute("data-bs-toggle", "modal");
    buttonElement.setAttribute("data-bs-target", popId);
    buttonElement.setAttribute("onclick", "UserFormUpdate(" + id + " );")

    buttonElement.type = 'button';
    buttonElement.textContent = cellData;
    buttonElement.classList.add('btn');
    buttonElement.classList.add('btn-outline-success');
    buttonElement.classList.add('btn-edit');

    cellElement.appendChild(buttonElement);

    return cellElement;
}

/**
 * Create Icon Cell 
 * @param {any} cellData
 * @returns
 */
function createIconCell(cellData) {
    const cellElement = document.createElement("td");
    cellElement.setAttribute("align", "center");
    const divElement = document.createElement("div");

    divElement.classList.add("ico" + iconName(cellData))


    cellElement.appendChild(divElement);

    return cellElement;

}

function createCell(cellData) {
    const cellElement = document.createElement("td");

    cellElement.textContent = cellData;

    return cellElement;
}

function UpdateRegionDropdown(items, id) {
    let currentElement = document.getElementById(id);

    currentElement.innerHTML = "";

    const firtsItem = document.createElement("option");
    firtsItem.setAttribute("value", "");
    firtsItem.textContent = "--Select--";
    firtsItem.setAttribute("selected", "disabled");


    currentElement.appendChild(firtsItem);

    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", value.id);
        item.textContent = value.name;

        currentElement.appendChild(item);
    }

}

function AddItemToDropdownItems(item, id) {
    let currentElement = document.getElementById(id);
    const currentItem = document.createElement("option");

    currentItem.setAttribute("value", item);
    currentItem.textContent = item;

    currentElement.appendChild(currentItem);
}

function GetElementAndSelectedInnerText(id) {
    const listElement = document.querySelector(id);

    //console.log("Select Index", listElement.selectedIndex);

    if (listElement.selectedIndex !== -1) {
        let selectedItem = listElement.options[listElement.selectedIndex].innerText;

        return selectedItem;
    }

    return "";
}



function GetElementAndSelectedValue(id) {
    const listElement = document.querySelector(id);
    let selectedItem = listElement.options[listElement.selectedIndex].value;

    return selectedItem;
}

function IsCheckBoxChecked(id) {
    let setStatusElement = document.querySelector(id);

    let status = setStatusElement.checked;

    return status;
}

function GetValueOfCheckRadioButton(list) {

    //console.log("length", list.length);

    let value = "";

    for (var i = 0; i < list.length; i++) {
        let radio = document.querySelector(list[i]);



        if (radio.checked) {
           // console.log("radio", radio);

            value = radio.value

            break;
        }
    }

    return value;

}

function SetValueOfCheckRadioButton(item, id) {

    for (const [key, value] of Object.entries(item)) {

        if (key == id) {
            let currentElement = document.querySelector(value);

            //console.log("selectd item", currentElement);
            currentElement.setAttribute("checked", "checked");
        }

    }
    

}

function GetDropdownList(id) {
    let currentElement = document.querySelector(id);

    let result = "";

    //console.log("option", currentElement.options)

    for (const [key, value] of Object.entries(currentElement.options)) {

       //console.log("items", key, value)

       // console.log("value", value.innerHTML)

        result += value.innerHTML + "~";

    }

    return result;

   
}

function RemoveItemFromDropdownList(id) {
    var element = document.getElementById(id);
    element.remove(element.selectedIndex);
}

function SetDivElementValue(id, value) {
    let currentElement = document.querySelector(id);

   // console.log("Div", currentElement);

    currentElement.setAttribute("value", value)
}
function SetDivElementText(id, value) {
    let currentElement = document.getElementById(id);

   // console.log("Div", currentElement);

    currentElement.setAttribute("value", value);
    currentElement.innerHTML = value;
}

function GetElementValueAtribute(id) {

    let currentElement = document.getElementById(id);

    return currentElement.getAttribute('value');

}

function FormClear(id) {
    document.getElementById(id).reset();
}

function UpdateDropdownItemsSelectByIndex(items, id, selectedIndex) {
    let testTypeElement = document.getElementById(id);



    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", key);
        if (key == selectedIndex) {
            item.setAttribute("selected", "selected");
        }
        item.textContent = value.name;

        testTypeElement.appendChild(item);
    }

}

//function LoadTempTable(id) {

//    console.log("Load Data Table")

//    const dataSet = [
//        ['1001', 'Moo, Mu', 'physician', 'family', '13 Huf Rd', '41655551111'],
//        ['1002', 'Klien, Mo', 'physician', 'cardiology', '19 MakelJackson', '4160001113'],
//        ['1003', 'Kavin, Kafi', 'physician', 'cardiology', '19 MakelJackson', '41655551515'],
//        ['1004', 'Lady Helper', 'physician', 'family', '23 Kokspr', '4165552313'],

//    ];

//    dataSet.forEach(r => {
//        var div1 = document.createElement('div');
//        div1.innerHTML = r[1];
//        r[1] = div1;

//        var div3 = document.createElement('div');
//        div3.innerHTML = r[3];
//        r[3] = div3;
//    })

//    console.log(dataSet);

//    var table = $(id).DataTable({
//        columns: [
//            { title: 'Id' },
//            { title: 'Name' },
//            { title: 'Type' },
//            { title: 'Specialty.' },
//            { title: 'Address' },
//            { title: 'Work Phone' }
//        ],
//        data: dataSet
//    });


//}

//function AddItemToDropdownItems(item, id) {
//    let currnetElement = document.getElementById(id);

//    const item = document.createElement("option");
//    item.setAttribute("value", item);
//    item.textContent = item;

//    currnetElement.appendChild(item);
    
//}
function UpdateDropdownItemsWithSelectByName(items, id, selectedName) {
    let testTypeElement = document.getElementById(id);



    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", key);
        if (value.name == selectedName) {
            item.setAttribute("selected", "selected");
        }
        item.textContent = value.name;

        testTypeElement.appendChild(item);
    }

}


function UpdateTestTypeDropdown(items, id) {
    let testTypeElement = document.getElementById(id);

    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", key);
        item.textContent = value.name;

        testTypeElement.appendChild(item);
    }

}

function ClearTextElement(id) {
    let currentElement = document.getElementById(id);
    //console.log(currentElement);

    currentElement.value = "";
    
}

function ClearInnerElement(id) {
    let currentElement = document.getElementById(id);
    //console.log(currentElement);

    currentElement.innerHTML = "";

}

function UpdatePhysicianSearchResult(items, id) {

    let currentElement = document.getElementById(id);

    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", value.physicianUID);
        item.textContent = value.physicianUID + " " + value.lastName + ", " + value.firstName;

        currentElement.appendChild(item);
    }

}

function UpdateLocationDropdown(items, id) {
    let currentElement = document.getElementById(id);

    currentElement.innerHTML = "";

    const firstItem = document.createElement("option");
    firstItem.setAttribute("value", "-1");
    firstItem.textContent = "--Select--";  
    currentElement.appendChild(firstItem);

    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", key);
        item.textContent = value.name;

        currentElement.appendChild(item);
    }

}



async function LoadRegions(id) {

    const response = await fetch("/Api/ListOf/AllRegions", {
        method: 'GET',
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },

    })
        .then(response => response.json())
        .then(response => {

            UpdateRegionDropdown(response, id);

        })

}

async function LoadTestTypes(id) {

    const response = await fetch("/Api/ListOf/AllTestType", {
        method: 'GET',
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },

    })
        .then(response => response.json())
        .then(response => {

            UpdateTestTypeDropdown(response, id);

        })

}

async function LoadLocations(id) {

    const response = await fetch("/Api/ListOf/AllLocations", {
        method: 'GET',
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },

    })
        .then(response => response.json())
        .then(response => {

           // console.log("loadLocation", response)

            UpdateLocationDropdown(response, id);

        })

}


async function SaveTermsData(data, id, userUid) {
   // console.log("Edit dialog called: ", id, data);

    const response = await fetch("/Api/AjaxService/SaveTermsData", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },
        body: JSON.stringify({ "TermsContent": data, "UserUID": userUid, "TestTypeUid": id })
    })
        //.then(response => response.json())
        /*.then(response => {

        //ApplyTermsEditData(response);
        })*/
}



function UpdateResponsiblePhysiciansDropdown(items, id) {
    console.log(items);

    let respPList = document.getElementById(id);
    respPList.innerHTML = "";
    const firstItem = document.createElement("option");
    firstItem.setAttribute("value", "-1");
    firstItem.textContent = "--Select--";  

    respPList.appendChild(firstItem);

    


    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", key);
        item.textContent = value.physicianNumber + " " + value.firstName + " " + value.lastName;

        respPList.appendChild(item);
    }

}

function UpdatePhysicianGroupsDropdown(items, id) {
    console.log(items);

    let groupsPList = document.getElementById(id);

    console.log("groups", groupsPList);
    groupsPList.innerHTML = "";

    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", key);
        item.textContent = value.name;

        groupsPList.appendChild(item);
    }

}

function UpdateTestTypeDropdown(items, id) {

    let testTypeElement = document.getElementById(id);
    testTypeElement.innerHTML = "";

    const firstItem = document.createElement("option");
    firstItem.setAttribute("value", "-1");
    firstItem.textContent = "--Select--"; 

    testTypeElement.appendChild(firstItem);

    console.log("tst", items)

    for (const [key, value] of Object.entries(items)) {
        //console.log(key, value.systemEmail);
        const item = document.createElement("option");
        item.setAttribute("value", value.id);
        item.textContent = value.name;

        testTypeElement.appendChild(item);
    }

}

function HideOrShowElement(id, action) {
    var currentDiv = document.getElementById(id);

    currentDiv.style.display = action;
}

async function LoadTestTypes(id) {

    const response = await fetch("/Api/ListOf/AllTestType", {
        method: 'GET',
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },

    })
        .then(response => response.json())
        .then(response => {

            console.log("Items", response);

            UpdateTestTypeDropdown(response, id);

        })

}




async function LoadResponsiblePhysicians(id) {

    const response = await fetch("/Api/ListOf/ResponsibleDoctors/?id=" + "0", {
        method: 'GET',
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },

    })
        .then(response => response.json())
        .then(response => {

            UpdateResponsiblePhysiciansDropdown(response, id);

        })

}

async function LoadPhysicianGroups(id) {

    const response = await fetch("/Api/ListOf/PhysicianGroups/?id=" + "0", {
        method: 'GET',
        headers: { 'Content-Type': 'application/json;charset=UTF-8' },

    })
        .then(response => response.json())
        .then(response => {

            UpdatePhysicianGroupsDropdown(response, id);


        })

}