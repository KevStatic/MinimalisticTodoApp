document.addEventListener("click", async (e) => {
    const btn = e.target.closest(".todo-delete");
    if (!btn) return;

    e.stopPropagation();

    const li = btn.closest(".todo-item");
    const id = li.dataset.id;

    if (!id) return;

    const confirmDelete = confirm("Delete this task?");
    if (!confirmDelete) return;

    btn.disabled = true;

    const res = await fetch(`/api/todo/${id}`, {
        method: "DELETE"
    });

    if (!res.ok) {
        alert("Failed to delete task");
        btn.disabled = false;
        return;
    }

    li.classList.add("removing");

    setTimeout(() => {
        li.remove();
    }, 200);
});
