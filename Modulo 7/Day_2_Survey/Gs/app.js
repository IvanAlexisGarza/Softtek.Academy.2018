'use strict';

var scope = {
    get() {
        return this.provisional;
    },
    set valor(parameter) {
        this.provisional = parameter;
    },
    provisional: ""
};

//div element
const Container = document.getElementById("question-container");

//data
let Element = "";

//currentID
let CurrId = 0;

//input text getter
document.getElementById("qName")
    .addEventListener("input", event => {
        scope.valor = event.target.value;
    });

//add an event listener to send btn
document.getElementById("btn-send")
    .addEventListener("click", SendHandler);

function SendHandler(event){   

    event.preventDefault();

    let text = scope.get();

    if(text.trim().length < 1) return false;

    AddNewQuestion(text);    
}

function AddNewQuestion(value){
    const id = IdMaker();
    let NewElement = `<div id="${id}" class="el-cont"><h2>${value}</h2><form action="" method="post">            
        <input type="text" name="" placeholder="type here..." class="text-box" />
        <input type="button" value="Add a new" class="btn btn-add" />

        <br />
        <br />

        <input type="radio" name="" id="">
        random text
        <button id="btn-del-${id}" class="btn btn-del">Delete</button>
    </form></div>`;

    // Element += NewElement;
    Reset();
    RenderElement(NewElement);
    CurrId = id;

    //delete handler
    document.getElementById(`btn-del-${id}`).addEventListener("click", e => {
        e.preventDefault();
        Delete(`${id}`);
    });
}

//idMaker
function IdMaker(){
    return CurrId + 1;
}

//reset value
function Reset(){
    let el = document.querySelector("#qName");

    el.value = "";
    el.textContent = "";

    scope.valor = "";
}

//delete element
function Delete(elem) {
    document.getElementById(elem).remove();
}

//render elements
function RenderElement(element){
    Container.insertAdjacentHTML(`beforeend`, element);
}
