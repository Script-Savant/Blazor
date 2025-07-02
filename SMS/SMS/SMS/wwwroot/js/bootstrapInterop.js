window.bootstrapInterop = {
    showModal: function (id) {
        const modal = new bootstrap.Modal(document.querySelector(id));
        modal.show();
    },
    hideModal: function (id) {
        const modalEl = document.querySelector(id);
        const modal = bootstrap.Modal.getInstance(modalEl);
        modal?.hide();
    }
};
