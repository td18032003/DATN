<template>
    <div class="">
        <div class="header">
            <div class="title">
                Vai trò
            </div>
            <div class="tool">
                <div class="search">
                    <cc-input :placeholderInput="'Tìm kiếm'"></cc-input>
                </div>
                <div class="add">
                    <cc-button>Thêm</cc-button>
                </div>
            </div>
        </div>
        <div class="table-show">
            <div class="table">
            <cc-table
                :listHeader="listHeader"
                :dataSource="dataSource"

            >
            </cc-table>
        </div>
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
                    DataField: "FileName",
                    Caption: "Tên file"
                },
                {
                    DataField: "Type",
                    Caption: "Loại file"
                }
            ],
            dataSource: [
                {
                    FileName: "Tuan Anh",
                    Type: "vjp"
                },
                {
                    FileName: "Tuan Anh",
                    Type: "vjp"
                },
                {
                    FileName: "Tuan Anh",
                    Type: "vjp"
                }
            ],
            type: 1
        }
    }
}
</script>
<style lang="scss" scoped>
.header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
}
    .title {

    }
    .tool {
        display: flex;
    }
        .search {
            margin-right: 20px;
        }
</style>