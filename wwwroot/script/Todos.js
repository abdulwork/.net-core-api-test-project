let makeTodo = document.querySelector(".new"),
    input = document.querySelector(".input"),
    ul = document.querySelector("ul"),
    todoInput = document.querySelector(".todo-input"),
    cancel = document.querySelector(".cancel"),
    ok = document.querySelector(".ok"),
    date = document.querySelector(".date"),
    g_IsChecked = false,
    today = new Date().toLocaleDateString();

date.textContent = today;

cancel.addEventListener("click", function (e) {
    e.preventDefault();
    input.classList.add("hide");
    makeTodo.classList.remove("hide");
    todoInput.value = "";
});

makeTodo.addEventListener("click", function (e) {
    e.preventDefault();
    input.classList.remove("hide");
    makeTodo.classList.add("hide");
    $("#hiddenid").val("");
});

ok.addEventListener("click", function (e) {
    if (todoInput.value != "") {
        e.preventDefault();
        var id = $("#hiddenid").val();
        if (id == "")
            saveTodoList(todoInput.value, false);
        else {
            saveletsDone(id, todoInput.value, g_IsChecked);

            var notesUpdate = document.getElementById(id);
            notesUpdate.parentElement.children[1].textContent = todoInput.value;

            $("#hiddenid").val("");
        }
        makeTodo.classList.remove("hide");;
        input.classList.add("hide");

    }
});



function letsDone(element) {
    element.addEventListener("click", function () {
        if (element.parentElement.children[1].style.textDecoration != "line-through") {
            element.parentElement.children[1].style.textDecoration = "line-through";
        } else {
            element.parentElement.children[1].style.textDecoration = "";
        }
        saveletsDone(element.id, element.nextElementSibling.textContent, element.checked);
    });
};

function listenDeleteTodo(element) {
    element.addEventListener("click", function (e) {
        debugger;
        e.preventDefault();
        element.parentElement.parentElement.remove();
        DeleteTodo(element.parentElement.parentElement.children[0].id);
    });
};

function listenEditTodo(element) {
    element.addEventListener("click", function (e) {
        debugger;
        e.preventDefault();
        input.classList.remove("hide");
        makeTodo.classList.add("hide");
        $("#hiddenid").val(element.parentElement.parentElement.children[0].id);
        $(".todo-input").val(element.parentElement.parentElement.children[1].textContent);
        g_IsChecked = element.parentElement.parentElement.children[0].checked;
    });
};

let body = document.querySelector("body"),
    backgrounds = [
        "#17a2b8",
        "tomato",
        "lightgreen",
        "brown"
    ],
    dot = document.querySelectorAll(".dot");

body.style.backgroundColor = backgrounds[0];
dot[0].classList.add("dot-active");

for (let i = 0; i < dot.length; i++) {
    dot[i].addEventListener("click", function () {
        for (let j = 0; j < dot.length; j++) {
            dot[j].classList.remove("dot-active");
        }
        dot[i].classList.add("dot-active");
        body.style.backgroundColor = backgrounds[i];
    });
};
