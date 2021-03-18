const baseApi = document.getElementById('api-url').value
function createNode(element) {
    return document.createElement(element);
}

function append(parent, el) {
    return parent.appendChild(el);
}

function GetListItemsPage(totalItems, top) {
    let indexDisplay = 1;
    let listResult = []
    for (let i = 0; i < totalItems; i++) {
        if (i % top === 0) {
            listResult.push({ take: (i + 1), index: indexDisplay })
            indexDisplay++
        }
    }

    return listResult
}

function createPreviousButton(hasPrevious, skip, top, endpoint, idList, idPaging, endpointEdit, chargerListFn) {
    let li = createNode('li')
    let btn = createNode('button')
    li.classList.add('page-item')
    if (hasPrevious) {
        li.onclick = function () { chargerListFn(skip, top, endpoint, idList, idPaging, endpointEdit) }
    } else {
        li.classList.add('disabled')
    }

    btn.classList.add('page-link')
    btn.innerText = 'Previous'
    append(li, btn)
    return li
}

function createNextButton(hasNext, skip, top, endpoint, idList, idPaging, endpointEdit, chargerListFn) {
    let li = createNode('li')
    let btn = createNode('button')
    li.classList.add('page-item')
    if (hasNext) {
        li.onclick = function () { chargerListFn(skip, top, endpoint, idList, idPaging, endpointEdit) }
    } else {
        li.classList.add('disabled')
    }

    btn.classList.add('page-link')
    btn.innerText = 'Next'
    append(li, btn)
    return li
}

function showValues(take, index) {
    alert(`$take: ${take}, index: ${index}`)
}

function chargeListCategories(skip, top, endpointCategories, idList, idPaging, endpointEdit) {
    let total
    const ul = document.getElementById(idList)
    ul.innerHTML = ''
    const ulPage = document.getElementById(idPaging)
    ulPage.innerHTML = ''
    const hasPrevious = ((skip - top) >= 0)
    append(ulPage, createPreviousButton(hasPrevious, (skip - top), top, endpointCategories, idList, idPaging, endpointEdit, chargeListCategories))

    const url = `${baseApi}Admin/${endpointCategories}?Skip=${skip}&Top=${top}`
    fetch(`${url}`, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(res => res.json())
        .then(function (data) {
            const totalItems = data.totalNumberOfItems
            total = data.totalNumberOfItems
            const list = GetListItemsPage(totalItems, top)
            list.map(function (item) {
                let li = createNode('li')
                li.classList.add('page-item')

                li.setAttribute('id', `${endpointCategories}-item-page-${item.index}`);
                if ((item.take - 1) === skip) {
                    li.classList.add('active')
                }
                li.onclick = function () { chargeListCategories((item.take - 1), top, endpointCategories, idList, idPaging, endpointEdit) }
                let btn = createNode('button')
                btn.classList.add('page-link')
                btn.innerText = item.index
                append(li, btn)
                append(ulPage, li)

            })

            return data.items.map(function (dd) {
                let a = createNode('a');
                a.href = `/${endpointEdit}/Edit/${dd.id}`
                let li = createNode('li');
                li.classList.add('list-group-item');
                li.classList.add('list-group-item-action');

                li.innerText = dd.title
                append(a, li)
                append(ul, a)
            })

        })
        .then(() => {
            const hasNext = (top + skip) < total
            append(ulPage, createNextButton(hasNext, (skip + top), top, endpointCategories, idList, idPaging, endpointEdit, chargeListCategories))
        })
        .catch(error => console.error('error', error));
}

chargeListCategories(0, 5, 'posts-admin', 'list-posts', 'pagination-posts', 'Posts');
chargeListCategories(0, 5, 'categories-admin', 'list-categories', 'pagination-categories', 'Categories');