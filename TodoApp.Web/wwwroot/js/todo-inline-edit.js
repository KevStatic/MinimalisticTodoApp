let isSaving = false;

/* ===============================
   CLICK → START EDIT
================================ */
document.addEventListener("click", function (e) {
    if (e.target.classList.contains("todo-text")) {
        startEdit(e.target);
    }
});

function startEdit(text) {
    const li = text.closest(".todo-item");
    const input = li.querySelector(".todo-edit");

    li.classList.add("editing");

    input.value = text.innerText;
    input.dataset.original = text.innerText;

    text.classList.add("hidden");
    input.classList.remove("hidden");

    input.focus();
    input.setSelectionRange(input.value.length, input.value.length);
}

/* ===============================
   KEYBOARD HANDLING
================================ */
document.addEventListener("keydown", function (e) {
    if (!e.target.classList.contains("todo-edit")) return;

    if (e.key === "Enter" && !e.shiftKey) {
        e.preventDefault();
        saveEdit(e.target);
    }

    if (e.key === "Escape") {
        cancelEdit(e.target);
    }
});

/* ===============================
   BLUR HANDLING (SMART)
================================ */
document.addEventListener(
    "blur",
    function (e) {
        if (
            e.target.classList.contains("todo-edit") &&
            !e.relatedTarget?.classList.contains("todo-check")
        ) {
            saveEdit(e.target);
        }
    },
    true
);

/* ===============================
   SAVE EDIT
================================ */
function saveEdit(input) {
    if (isSaving) return;
    isSaving = true;

    const li = input.closest(".todo-item");
    const text = li.querySelector(".todo-text");
    const newValue = input.value.trim();
    const original = input.dataset.original;

    if (newValue === "" || newValue === original) {
        cancelEdit(input);
        isSaving = false;
        return;
    }

    // Optimistic UI
    text.innerText = newValue;
    finishEdit(input);

    updateTitle(li.dataset.id, newValue, original, text);

    setTimeout(() => {
        isSaving = false;
    }, 100);
}

/* ===============================
   CANCEL EDIT
================================ */
function cancelEdit(input) {
    const li = input.closest(".todo-item");
    li.querySelector(".todo-text").innerText = input.dataset.original;
    finishEdit(input);
}

/* ===============================
   FINISH EDIT (UI RESET)
================================ */
function finishEdit(input) {
    const li = input.closest(".todo-item");

    input.classList.add("hidden");
    li.querySelector(".todo-text").classList.remove("hidden");
    li.classList.remove("editing");
}

/* ===============================
   BACKEND SYNC
================================ */
function updateTitle(id, title, oldTitle, text) {
    fetch("/Todo/UpdateTitle", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ id, title })
    }).catch(() => {
        // Rollback on failure
        text.innerText = oldTitle;
        alert("Failed to update task");
    });
}
