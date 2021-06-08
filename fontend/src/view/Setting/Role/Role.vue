<template>
    <div class="role-view">
        <div class="header">
            <div class="title">
                <span>Vai trò</span>
            </div>
            <div class="flex">
                <cc-input class="m-r-12" width="250px" icon="icon-search" placeholderInput="Tìm kiếm vai trò"></cc-input>
                <cc-button type="primary" icon="icon-plus-white" @click="openAdd">Thêm</cc-button>
            </div>
        </div>
        <div class="table-show">
            <cc-table
                :listHeader="listHeader"
                :dataSource="dataSource"

            >
            </cc-table>
        </div>
    </div>
</template>
<script>
import CcButton from '../../../components/button/ccButton.vue'
import CcInput from '../../../components/input/ccInput.vue'
export default {
    components: { CcInput, CcButton },
    data(){
        return{
            open: false,
            content: "",
            openContent: false,
            inputFile: null,
            listHeader: [
                {
                    DataField: "RoleName",
                    Caption: "Tên vai trò"
                },
                {
                    DataField: "Note",
                    Caption: "Ghi chú"
                }
            ],
            dataSource: [
                {
                    RoleName: "Quản trị hệ thống",
                    Note: "admin của chương trình"
                },
                {
                    RoleName: "Quản lý nhân sự",
                    Note: "Quản lý các phần trong chương trình"
                },
                {
                    RoleName: "Nhân sự",
                    Note: "Người dùng bình thường"
                }
            ],
            type: 1
        }
    }
}
</script>
<style lang="scss" scoped>
.role-view{
    height: 100%;
    .header{
        height: 36px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 12px;
        .title{
            font-size: 18px;
            font-weight: 500;
        }
    }
    .table-show{
        height: calc(100% - 60px);
    }
}
</style>