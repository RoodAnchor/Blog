let tagIds = [];
function AddTag(checkbox) {
    let tagId = parseInt(checkbox.id.replace("tag-", ""));

    if (checkbox.checked)
        tagIds.push(tagId);
    else
        tagIds.splice(tagIds.indexOf(tagId), 1);

    document.getElementById("selectedTagIds").value = tagIds;
}