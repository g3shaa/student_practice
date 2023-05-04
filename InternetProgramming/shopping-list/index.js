let ul = document.querySelector("ul");
let input = document.querySelector("input");
let button = document.querySelector("button")


//проверка дали има въведени данни
function afterClick() {
	if (input.value.length > 0) {
		createListItem();
	} else {
		alert("Please fill all fields")
	}
}

//когато се натисне ENTER да се записва записа въведен в текстовото поле
function afterPress(event) {
	if (input.value.length > 0 && event.key === "Enter") {
		createListItem();
	}
}

button.addEventListener("click", afterClick);


input.addEventListener("keypress", afterPress);

//добавяне на записа въведен в текстовото поле
function createListItem() {
	let li = document.createElement("li");
	li.textContent = input.value;

	let deleteBtn = document.createElement("button");
	deleteBtn.textContent = "Delete";
	deleteBtn.addEventListener("click", function () {
		ul.removeChild(li);
	});

	li.appendChild(deleteBtn);
	ul.appendChild(li);

	input.value = null;
}

let deleteBtn = document.createElement("button");
deleteBtn.textContent = "Delete";
deleteBtn.addEventListener("click", function () {
	ul.removeChild(li);
});