<template>
  <div class="content">
    <div class="header-content flex">
      <TitleSalary />
      <div class="box-btn-add">
        <button class="m-btn btn-add" @click="openModal">
          <div class="icon-add"></div>
          <div class="text-btn">Thêm mới</div>
        </button>
      </div>
    </div>
    <div class="toolbar-content flex relative" v-if="countRowChecked == 0">
      <div class="box-search relative">
        <input
          type="text"
          class="m-input input-search"
          placeholder="Tìm kiếm"
          v-model="keysearch"
          @keyup.enter="searchByKeysearch"
        />
        <div class="icon-search"></div>
      </div>
      <div class="toolbar-right flex">
        <BaseDropdown
          style="margin-right: 20px"
          :data="statusData"
          :widthDropdown="120"
          :widthDropdownData="230"
          :topDropdownData="42"
          :rightDropdownData="0"
          @get="getValueStatus"
        />
        <BaseDropdownSingle
          style="margin-right: 10px; width: 316px"
          :treeDataSource="treeDataSource"
          :placeholderProp="'Tất cả đơn vị'"
          :valueExprProp="'OrganizationUnitID'"
          :displayExprProp="'OrganizationUnitName'"
          :parentIdExprProp="'ParentID'"
          :valueDefault="treeDataSource && treeDataSource.length > 0 ? treeDataSource[7].OrganizationUnitID : null"
        />
        <div class="box-filter-toolbar">
          <div class="icon-filter-toolbar"></div>
        </div>
        <div class="box-setting-toolbar">
          <div class="icon-setting-toolbar"></div>
        </div>
      </div>
    </div>
    <div class="toolbar-content flex relative" v-else>
      <span class="text-toolbar"
        >Đã chọn <b>{{ countRowChecked }}</b></span
      >
      <span class="uncheck-all" @click="uncheckAll">Bỏ chọn</span>
      <div class="box-btn-unfollow-all">
        <button class="m-btn btn-unfollow-all">
          <div class="icon-unfollow"></div>
          <div class="text-btn">Ngừng theo dõi</div>
        </button>
      </div>
      <div class="box-btn-deletes">
        <button class="m-btn btn-deletes">
          <div class="icon-deletes"></div>
          <div class="text-btn">Xoá</div>
        </button>
      </div>
    </div>
    <div class="table-salary">
      <BaseGrid
        ref="baseGrid"
        :headers="headers"
        :dataSource="dataSource"
        @getRowChecked="getRowChecked"
      >
        <template #StatusName="{ data }">
          <div
            class="box-status flex a-l-c"
            v-if="data.StatusName == 'Đang theo dõi'"
          >
            <div class="icon-status"></div>
            <div class="text-status">{{ data.StatusName }}</div>
          </div>
          <div class="box-status flex a-l-c" v-else>
            <div
              class="icon-status"
              style="background-color: rgb(255, 153, 0)"
            ></div>
            <div class="text-status" style="color: rgb(255, 153, 0)">
              {{ data.StatusName }}
            </div>
          </div>
        </template>
        <template #Quota="{ data }">
          {{ formatPrice(data.Quota) }}
        </template>
      </BaseGrid>

      <div class="paging">
        <div class="amount">
          Tổng số bản ghi: <b>{{ amountPage }}</b>
        </div>
        <div class="pagination flex a-l-c">
          <span style="margin-right: 20px">Số bản ghi/trang</span>
          <BaseDropdown
            style="margin-right: 30px"
            :data="dataPage"
            :widthDropdown="60"
            :widthDropdownData="60"
            :topDropdownData="-150"
            :rightDropdownData="10"
            @get="getValuePageSize"
          />
          <div class="pageIndex flex a-l-c">
            <div style="margin-right: 70px">
              <span
                ><b>{{ startRecord }}</b
                ><span style="margin-left: 3px; margin-right: 3px">-</span
                ><b>{{ endRecord }}</b> bản ghi</span
              >
            </div>
            <paginate
              :page-count="numPages"
              :margin-pages="1"
              :container-class="'pagination'"
              :page-class="'page-item'"
              :prev-link-class="'btn-pre'"
              :next-link-class="'btn-next'"
              :click-handler="clickPaging"
              ref="pagination"
            >
            </paginate>
          </div>
        </div>
      </div>
    </div>
    <SalaryDetail
      ref="modeForm"
      :isOpenModal="isOpenModal"
      @closeForm="closeForm"
    />
  </div>
</template>

<script>
import TitleSalary from "../../components/base/BaseTitle.vue";
import BaseDropdownSingle from "../../components/base/BaseDropdownSingle.vue";
import BaseGrid from "../../components/base/BaseGrid.vue";
import SalaryDetail from "../salary/SalaryDetail.vue";
import { URL_API } from "../../js/common/data.js";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
import axios from "axios";
export default {
  name: "SalaryList",
  components: {
    TitleSalary,
    // BaseDropdown,
    BaseDropdownSingle,
    BaseGrid,
    SalaryDetail,
    BaseDropdown,
  },
  data() {
    return {
      // mở modal
      isOpenModal: true,
      // data source treeview
      treeDataSource: [],
      // count rowchecked
      countRowChecked: 0,
      // data source grid
      dataSource: [],
      // header grid
      headers: [
        {
          DataField: "SalaryCompositionCode",
          Caption: "Mã thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: true,
        },
        {
          DataField: "SalaryCompositionName",
          Caption: "Tên thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: true,
        },
        {
          DataField: "SalaryCompositionTypeName",
          Caption: "Loại thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "NatureName",
          Caption: "Tính chất",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "OrganizationUnitName",
          Caption: "Đơn vị áp dụng",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "TaxableName",
          Caption: "Chịu thuế",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "ReduceName",
          Caption: "Giảm trừ khi tính thuế",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Quota",
          Caption: "Định mức",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Cost",
          Caption: "Giá trị",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Description",
          Caption: "Mô tả",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "StatusName",
          Caption: "Trạng thái",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
      ],
      statusData: [
        { Text: "Tất cả trạng thái", Value: "" },
        { Text: "Đang theo dõi", Value: 0 },
        { Text: "Ngừng theo dõi", Value: 1 },
      ],
      dataPage: [
        { Text: "15", Value: 15 },
        { Text: "25", Value: 25 },
        { Text: "50", Value: 50 },
        { Text: "100", Value: 100 },
      ],
      // trang hiện tại
      pageIndex: 1,
      // value pageSize
      pageSize: 15,
      // value status
      statusID: "",
      // value dropdown filter
      organizationUnitID: "",
      // value input search
      keysearch: "",
      // tổng số bản ghi
      amountPage: 0,
      // tổng số trang
      numPages: 0,
      // bắt đầu từ bản ghi
      startRecord: 0,
      // kết thúc tại bản ghi
      endRecord: 0,
      page: 1,
      // mode form detail : 0 là add, 1 là edit
      modeFormDetail: 0,
    };
  },
  created() {
    // lấy ra toàn bộ danh sách
    this.getSalaryCompositionByFilter(
      this.pageIndex,
      this.pageSize,
      this.statusID,
      this.organizationUnitID,
      this.keysearch
    );
    this.getOrganizationUnits();
  },
  methods: {
    /**----------------------------------------------------
     * Lấy ra danh sách thành phần lương theo filter
     * CreatedBy:LQNHAT(19/09/2021)
     */
    getSalaryCompositionByFilter() {
      var self = this;
      axios
        .get(
          URL_API.API_SALARYCOMPOSITION +
            "/filter?pageIndex=" +
            self.pageIndex +
            "&pageSize=" +
            self.pageSize +
            "&statusID=" +
            self.statusID +
            "&organizationUnitID=" +
            self.organizationUnitID +
            "&keysearch=" +
            self.keysearch
        )
        .then((res) => {
          // lấy ra data
          self.dataSource = res.data.Data;
          // lấy ra tổng số bản ghi
          self.amountPage = res.data.TotalRecord;
          // lấy ra số lượng trang
          self.numPages = res.data.TotalPage;
          // set value startRecord, endRecord
          self.startRecord = (self.pageIndex - 1) * self.pageSize + 1;
          self.endRecord =
            self.amountPage < self.pageSize * self.pageIndex
              ? self.amountPage
              : self.pageSize * self.pageIndex;
        });
    },

    reloadTableAndFilter() {
      var self = this;
      axios
        .get(
          URL_API.API_SALARYCOMPOSITION +
            "/filter?pageIndex=" +
            self.pageIndex +
            "&pageSize=" +
            self.pageSize
        )
        .then((res) => {
          // lấy ra data
          self.dataSource = res.data.Data;
          // lấy ra tổng số bản ghi
          self.amountPage = res.data.TotalRecord;
          // lấy ra số lượng trang
          self.numPages = res.data.TotalPage;
          // set value startRecord, endRecord
          self.startRecord = (self.pageIndex - 1) * self.pageSize + 1;
          self.endRecord =
            self.amountPage < self.pageSize * self.pageIndex
              ? self.amountPage
              : self.pageSize * self.pageIndex;
          self.$refs.pagination.selectFirstPage();
        });
    },

    /**------------------------------------------------------------------------
     * Lấy ra danh sách đơn vị
     * CreatedBy:LQNHAT(20/09/2021)
     */
    getOrganizationUnits() {
      var self = this;
      axios.get(URL_API.API_ORGANIZATIONUNIT).then((res) => {
        self.treeDataSource = res.data;
        console.log(self.treeDataSource);
        console.log("value: " + self.treeDataSource[0].OrganizationUnitID);
      });
    },

    /**-------------------------------------------------------------------
     * Bắt sự kiện chuyển trang
     * CreatedBy:LQNHAT(20/09/2021)
     */
    clickPaging(pageNum) {
      this.pageIndex = pageNum;
      this.getSalaryCompositionByFilter(
        this.pageIndex,
        this.pageSize,
        this.statusID,
        this.organizationUnitID,
        this.keysearch
      );
    },

    /**------------------------------------------------
     * Bắt sự kiện mở form chi tiết
     * CreatedBy: LQNHAT(14/09/2021)
     */
    openModal() {
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = 0;
      this.$refs.modeForm.show(this.modeFormDetail);
    },

    /**---------------------------------------------------------
     * Bắt sự kiện đóng form chi tiết
     * CreatedBy : LQNHAT(14/09/2021)
     */
    closeForm() {
      this.isOpenModal = true;
    },

    /**-----------------------------------
     * Set value cho status để filter
     * CreatedBy : LQNHAT(14/09/2021)
     */
    getValueStatus(value) {
      this.statusID = value;
      console.log("StatusID: " + this.statusID);
      this.getSalaryCompositionByFilter(
        this.pageIndex,
        this.pageSize,
        this.statusID,
        this.organizationUnitID,
        this.keysearch
      );
    },

    /**------------------------------------
     * Set value cho pageSize
     * CreatedBy: LQNHAT(16/09/2021)
     */
    getValuePageSize(value) {
      this.pageSize = value;
      console.log("pageSize: " + this.pageSize);
      this.getSalaryCompositionByFilter(
        this.pageIndex,
        this.pageSize,
        this.statusID,
        this.organizationUnitID,
        this.keysearch
      );
    },

    /**---------------------------------------------------------
     * Lấy ra số dòng đã được checked
     * CreatedBy: LQNHAT(17/09/2021)
     */
    getRowChecked(selectedRowsData) {
      this.countRowChecked = selectedRowsData.length;
    },

    /**-----------------------------------------------------------
     * Hàm bắt sự kiện khi có text thì search theo text
     * CreateBy: LQNhat(20/09/2021)
     */
    searchByKeysearch() {
      if (this.keysearch == "") {
        this.reloadTableAndFilter();
      } else {
        this.pageIndex = 1;
        this.getSalaryCompositionByFilter(
          this.pageIndex,
          this.pageSize,
          this.statusID,
          this.organizationUnitID,
          this.keysearch
        );
      }
    },

    /*---------------------------------------------------------
     * Bắt sự kiện bỏ chọn
     * CreatedBy:LQNHAT(17/09/2021)
     */
    uncheckAll() {
      this.$refs.baseGrid.uncheckAllRow();
    },

    /**
     * Hàm format lương trên table
     * CreateBy:LQNhat(17/09/2021)
     */
    formatPrice(value) {
      let val = (value / 1).toFixed(0).replace(".", ",");
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    },
  },
};
</script>

<style>
[v-cloak] {
  display: none;
}
</style>