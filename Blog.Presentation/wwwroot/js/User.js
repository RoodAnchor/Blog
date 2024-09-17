let roleIds = document.getElementById('selectedRoleIds').value.split(',');

function AddRole(checkbox) {
    let roleId = checkbox.id.replace("role-", "")

    if (checkbox.checked)
        roleIds.push(roleId);
    else
        roleIds.splice(roleIds.indexOf(roleId), 1);

    document.getElementById("selectedRoleIds").value = roleIds;
}