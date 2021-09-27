<template>
  <div
    class="customize-column"
    :class="{ 'hidden-column': hiddenCustomizeColumn }"
  >
    <div class="content-customize">
      <div class="header-customize flex a-l-c">
        <div class="title-header">Tùy chỉnh cột</div>
        <div
          class="icon-refresh"
          title="Lấy lại mặc định"
          @click="refreshColumn"
        ></div>
      </div>
      <div class="box-search relative box-search-column">
        <input
          type="text"
          class="m-input input-search input-search-column"
          v-model="keysearch"
          placeholder="Tìm kiếm"
        />
        <div class="icon-search-column"></div>
      </div>
      <div class="box-cloumn-header">
        <draggable v-model="headersSalary">
          <transition-group>
            <div v-for="element in headersSalary" :key="element.DataField">
              <div
              v-if="show(element)"
                class="item-column relative flex a-l-c"
                @click="toggleCheckbox(element)"
              >
                <div
                  class="icon-checkbox-filter-default"
                  :class="{
                    'icon-checkbox-filter-default': !element.Checked,
                    'icon-checkboc-filter-checked': element.Checked,
                  }"
                ></div>
                <div class="text-checkbox-column">{{ element.Caption }}</div>
                <div class="box-icon-draggable">
                  <div class="icon-draggable"></div>
                </div>
              </div>
            </div>
          </transition-group>
        </draggable>
      </div>
      <div class="footer-customize-column">
        <div class="box-btn-add box-btn-save-column">
          <button class="m-btn btn-add btn-save-column" @click="saveColumn">
            <div class="text-btn">Lưu</div>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import draggable from "vuedraggable";
export default {
  name: "BaseCustomizeColumn",
  // props: ["hiddenCustomizeColumn", "headers"],
  props: {
    hiddenCustomizeColumn: {
      type: Boolean,
    },
    headers: {
      type: Array,
    },
    headerGrid: {
      type: Array,
    },
    headersDefault: {
      type: Array,
    },
  },
  components: {
    draggable,
  },
  data() {
    return {
      showIconDefault: false,
      headersSalary: this.headers,
      keysearch: "",
    };
  },
  watch: {
    headers(data) {
      this.headersSalary = data;
    },
    keysearch() {
      this.searchByKeysearch();
    },
  },
  methods: {
    /**-----------------------------------------------------------------------------
     * Filter theo keysearch
     * CreatedBy: LQNHAT(26/09/2021)
     */
    searchByKeysearch() {
      if (this.keysearch != null && this.keysearch.length > 0) {
        this.headersSalary = [];
        this.headers.forEach((element) => {
          if (
            element.Caption.toLowerCase().includes(this.keysearch.toLowerCase())
          )
           {
             this.headersSalary.push(element);
          }
        });
      }
      else
      {
        this.headersSalary = this.headers;
      }
    },
    show(item)
    {
      return item.Caption.toLowerCase().includes(this.keysearch.toLowerCase());
    },
    /**----------------------------------------------------------------------
     * Ẩn hiện icon checkbox
     * CreatedBy: LQNHAT(20/09/2021)
     */
    toggleCheckbox(element) {
      element.Checked = !element.Checked;
    },

    /**----------------------------------------------------------------------
     * Lưu trạng thái column
     * CreatedBy: LQNHAT(24/09/2021)
     */
    saveColumn() {
      this.keysearch = "";
      this.$emit("customizeColumn", this.headersSalary);
      this.$emit("closeCustomizeColumn");
    },

    /**---------------------------------------------------------------------
     * Refresh column
     * CreatedBy: LQNHAT(24/09/2021)
     */
    refreshColumn() {
      this.$emit("refreshColumn");
      this.$emit("closeCustomizeColumn");
    },

    /**----------------------------------------------------------------------
     * Hàm check event khi click ra bên ngoài tùy chỉnh cột
     * CreateBy: LQNhat(20/09/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.$emit("closeCustomizeColumn");
        this.keysearch = null;
      }
    },
  },
  mounted() {
    document.addEventListener("click", this.close);
  },
};
</script>

<style>
</style>