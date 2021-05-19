<template>
    <div class="body-receive">
        <div class="body-content">
            <div class="header flex">
                <div class="flex">
                    <div class="tilte">Không giới hạn</div>
                </div>
                <div class="flex">
                    <cc-input class="m-r-12" icon="icon-search" placeholderInput="Tìm kiếm tài liệu"></cc-input>
                    <cc-button type="primary m-r-12" icon="icon-plus-white">Chia sẽ</cc-button>
                    <cc-icon type="primary-border" icon="icon-filter"></cc-icon>
                </div>
            </div>
            <div class="content-list">
                <ccTable 
                    :listHeader="listHeader" 
                    :dataSource="dataSource"
                    @clickEdit="openEdit"
                    @clickDelete="confirmDelete">
                </ccTable>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            typeshow: 1,
            listFolder: [
                {
                    FileID: 1,
                    FileName: "Thư mục 1",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 2",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 3",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 4",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 5",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 6",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 7",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                },
                {
                    FileID: 1,
                    FileName: "Thư mục 8",
                    Size: '100kb',
                    CreatedDate: '17/5/2021',
                    ParentID: 0
                }
            ],

            listHeader: [
                {
                    DataField: "FileName",
                    Caption: "Tên tệp",
                    DataTyle: "text",
                    Fixed: true,
                    MinWidth: 150
                },
                {
                    DataField: "CreatedBy",
                    Caption: "Người chia sẽ",
                    DataTyle: "text",
                    Fixed: true,
                    MinWidth: 150
                },
                {
                    DataField: "SharedDate",
                    Caption: "Ngày hết hạn",
                    DataTyle: "date",
                    Fixed: true,
                    MinWidth: 150
                },
                {
                    DataField: "TypeFile",
                    Caption: "Loại file",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "NoteShared",
                    Caption: "Ghi chú",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Size",
                    Caption: "Kích thước",
                    DataTyle: "text",
                    MinWidth: 150
                },
            ],
            dataSource: [],
        }
    }
}
</script>
<style lang="scss" scoped>
@import '@/styles/var-color.scss';
.body-receive{
    width: 100%;
    height: 100%;
    .body-content{
        position: absolute;
        top: 0;
        right: 0;
        bottom: 0;
        left: 233px;
        padding: 0 24px 24px 24px;
        .header{
            display: flex;
            align-items: center;
            
            padding: 12px 0px;
            justify-content: space-between;
            .tilte{
                font-weight: 500;
                font-size: 18px;
            }
        }
    }
    .content-list{
        display: flex;
        flex-wrap: wrap;
        height: calc(100% - 68px) !important;
        height: auto;
        overflow: auto;
        .item{
            height: 48px;
            margin: 0px 8px 4px 0px;
            .item-folder-list{
                align-items: center;
                width: 480px;
                height: 48px;
                padding: 0 8px;
                border-radius: 4px;
                background-color: #ffffff;
                border: 1px solid #ffffff;
                .img-folder{
                    width: 28px;
                    height: 28px;
                }
                .text-name{
                    width: 200px;
                    text-overflow: ellipsis;
                    justify-content: left;
                }
                &:hover{
                    border: 1px solid $primary-hover;
                    background-color: #d7e2ff !important;
                    cursor: pointer;
                    .btn-none{
                        display: flex !important;
                        float: right;
                    }
                }
            }
        }
    }
    .type{
        border-radius: 4px;
        background-color: #c1c1c1;
        .active{
            background-color: #ffffff;
        }
    }
    .type-show{
        width: 36px;
        height: 36px;
        border-radius: 4px;
        display: flex;
        align-items: center;
        justify-content: center;
    }
}
</style>