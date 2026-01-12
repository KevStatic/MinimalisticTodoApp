const input = document.getElementById("new-task-input");
const list = document.getElementById("todo-list");

input.addEventListener("keydown", async (e) => {
    if (e.key !== "Enter") return;

    const title = input.value.trim();
    if (!title) return;

    // 1️⃣ Create todo
    const res = await fetch("/api/todo/create", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ title })
    });

    if (!res.ok) {
        alert("Failed to add task");
        return;
    }

    // 2️⃣ Fetch latest todo
    const latestRes = await fetch("/api/todo/latest");
    const todo = await latestRes.json();

    // 3️⃣ Append to DOM
    list.insertAdjacentHTML("afterbegin", renderTodo(todo));

    input.value = "";
});

function renderTodo(todo) {
    return `
<li class="todo-item" data-id="${todo.id}">
    <input type="checkbox" class="todo-check" />
    <span class="todo-text">${todo.title}</span>
    <input class="todo-edit hidden" />

    <button class="todo-delete" aria-label="Delete">🗑</button>
</li>
`;
}

