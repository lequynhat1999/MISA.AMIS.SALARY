<template>
  <div
    class="customize-column"
    :class="{ 'hidden-column': hiddenCustomizeColumn }"
  >
    <div class="content-customize">
      <div class="header-customize flex a-l-c">
        <div class="title-header">Tùy chỉnh cột</div>
        <div class="icon-refresh" title="Lấy lại mặc định"></div>
      </div>
      <div class="box-search relative box-search-column">
        <input
          type="text"
          class="m-input input-search input-search-column"
          placeholder="Tìm kiếm"
        />
        <div class="icon-search-column"></div>
      </div>
      <div class="box-cloumn-header">
        <draggable v-model="listHeader">
          <transition-group>
            <div v-for="element in listHeader" :key="element.DataField">
              <div
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
          <button class="m-btn btn-add btn-save-column">
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
  props: ["hiddenCustomizeColumn", "headers"],
  components: {
    draggable,
  },
  data() {
    return {
      listHeader: this.headers,
      showIconDefault: false,
      isHiddenColumn: this.hiddenCustomizeColumn,
    };
  },
  methods: {
    /**----------------------------------------------------------------------
     * Ẩn hiện icon checkbox
     * CreatedBy: LQNHAT(20/09/2021)
     */
    toggleCheckbox(element) {
      element.Checked = !element.Checked;
    },

    /**----------------------------------------------------------------------
     * Hàm check event khi click ra bên ngoài tùy chỉnh cột
     * CreateBy: LQNhat(20/09/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target) && this.hiddenCustomizeColumn == false) {
        this.$emit("closeCustomizeColumn");
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