// var scope = {
//     get valor() {
//         return this.provisional;
//     },
//     set valor(parametro) {
//         this.provisional = parametro;
//         document.querySelector("#result").innerHTML = this.provisional;
//     },
//     provisional: ""
// };

// function agregar(parametro) {
//     console.log('algo')
// }

// document.querySelector("#questionName").addEventListener('input', function (event) {
//     scope.valor = event.target.value;

// })

// const object = {
//     consola:function console() {
//         console.log(this);
//     },
//     name: 'my personal object'
// }

function newElement() {
    var li = document.createElement("li");
    var li = document.createElement("lu");
    var inputValue = document.getElementById("myInput").value;
    var t = document.createTextNode(inputValue);
    var input = document.createElement("input")
    li.appendChild(t);
    if (inputValue === '') {
        alert("You must write something!");
    } else {
        document.getElementById("myUL").appendChild(li);
    }
    document.getElementById("myInput").value = "";
}


// var strs = ["String 1", "String 2", "String 3"];
// var list = document.createElement("ul");
// for (var i in strs) {
//     var anchor = document.createElement("a");
//     anchor.href = "#";
//     anchor.innerText = strs[i];

//     var elem = document.createElement("li");
//     elem.appendChild(anchor);
//     list.appendChild(elem);
// }
