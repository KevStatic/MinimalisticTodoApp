document.addEventListener("click", async (e) => {
    const btn = e.target.closest(".todo-delete");
    if (!btn) return;

    const li = btn.closest(".todo-item");
    const id = li.dataset.id;

    try {
        const res = await fetch(`/api/todo/${id}`, {
            method: "DELETE"
        });

        if (!res.ok) throw new Error();

        // smooth UI removal
        li.style.opacity = "0";
        li.style.height = "0";
        li.style.margin = "0";
        setTimeout(() => li.remove(), 200);

    } catch {
        console.error("Delete failed");
    }
});
