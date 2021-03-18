


var Size = Quill.import('attributors/style/size');
Size.whitelist = ['8px', '9px', '10px', '11px', '12px', '14px', '16px', '18px', '20px', '22px', '26px', '32px', '48px', '56px', '64px', '72px'];
Quill.register(Size, true);

var toolbarOptions = [
    ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
    ['blockquote', 'code-block'],

    [{ 'header': 1 }, { 'header': 2 }],               // custom button values
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
    [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
    [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
    [{ 'direction': 'rtl' }],                         // text direction

    [{ 'size': ['8px', '9px', '10px', '11px', '12px', '14px', '16px', '18px', '20px', '22px', '26px', '32px', '48px', '56px', '64px', '72px'] }],  // custom dropdown
    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

    [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
    [{ 'font': [] }],
    [{ 'align': [] }],

    ['clean'],                                       // remove formatting button
    ['link', 'image']
];
var options = {
    theme: 'snow',
    placeholder: 'Type your text here!',
    modules: {
        toolbar: toolbarOptions
    }
};

var quill = new Quill('#Tekst', options);
if (quill) {
    console.log('quill valid');
    quill.on('text-change', function () {
        messageFormUnsaved = true;
    });
} else {
    console.log('quill invalid');
}


function save() {
    quillEstVide();
}

function quillEstVide() {
    const element = document.querySelector('.ql-editor');
    const elementTextQuill = document.querySelector('#text-quill');
    const elementTexteErreur = document.querySelector('#texteErreur')
    const estVide = element.innerHTML === '<p><br></p>';
    if (estVide) {
        elementTextQuill.style['border-style'] = 'solid';
        elementTextQuill.style.border = '1px solid #ced4da';
        elementTextQuill.style['border-color'] = '#bd2426';
        elementTexteErreur.innerHTML = '<span class="text-danger field-validation-error" data-valmsg-for="Texte" data-valmsg-replace="true"><span>Le champ \'Content\' est requis.</span></span>';
    } else {
        elementTextQuill.style.removeProperty('border-style');
        elementTextQuill.style.removeProperty('border');
        elementTextQuill.style.removeProperty('border-color');
        elementTexteErreur.innerHTML = '';
    }
}

var form = document.querySelector('form');
form.onsubmit = function () {

    var description = document.querySelector('input[name=Content]');
    description.value = quill.root.innerHTML;
};